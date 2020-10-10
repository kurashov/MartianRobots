using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Common.Contracts;
using MartianRobots.Contracts;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace MartianRobots.IntegrationTest
{
    [TestFixture]
    public class IntegrationTests
    {
        private CompositionContainer _container;

        private IMarsSurfaceFactory _marsSurfaceFactory;
        private IMartianRobotFactory _martianRobotFactory;

        private readonly List<MoveAction> _firstRobotCommands = new List<MoveAction>()
        {
            //RFRFRFRF
            MoveAction.TurnRight,
            MoveAction.Forward,
            MoveAction.TurnRight,
            MoveAction.Forward,
            MoveAction.TurnRight,
            MoveAction.Forward,
            MoveAction.TurnRight,
            MoveAction.Forward
        };

        private readonly List<MoveAction> _secondRobotCommands = new List<MoveAction>()
        {
            //FRRFLLFFRRFLL
            MoveAction.Forward,
            MoveAction.TurnRight,
            MoveAction.TurnRight,
            MoveAction.Forward,
            MoveAction.TurnLeft,
            MoveAction.TurnLeft,
            MoveAction.Forward,
            MoveAction.Forward,
            MoveAction.TurnRight,
            MoveAction.TurnRight,
            MoveAction.Forward,
            MoveAction.TurnLeft,
            MoveAction.TurnLeft
        };

        private readonly List<MoveAction> _thirdRobotCommands = new List<MoveAction>()
        {
            //LLFFFLFLFL
            MoveAction.TurnLeft,
            MoveAction.TurnLeft,
            MoveAction.Forward,
            MoveAction.Forward,
            MoveAction.Forward,
            MoveAction.TurnLeft,
            MoveAction.Forward,
            MoveAction.TurnLeft,
            MoveAction.Forward,
            MoveAction.TurnLeft
        };

        [SetUp]
        public void Setup()
        {
            var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var modulesPath = Path.Combine(assemblyLocation!, "..\\..\\Modules\\netstandard2.0");

            //Setup the container
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(modulesPath) );

            _container = new CompositionContainer(catalog);

            _container.Compose(new CompositionBatch());
            _marsSurfaceFactory = _container.GetExportedValue<IMarsSurfaceFactory>();
            _martianRobotFactory = _container.GetExportedValue<IMartianRobotFactory>();
        
        }

        [TearDown]
        public void TearDown()
        {
            _container.Dispose();
        }

        [Test]
        public void IntegrationTest()
        {
            var surface = _marsSurfaceFactory.Create( new Vector2(5, 3) );

            var firstRobot = _martianRobotFactory.Create( surface,
                new Vector2( 1, 1 ),
                Direction.East );

            var secondRobot = _martianRobotFactory.Create( surface,
                new Vector2( 3, 2 ),
                Direction.North );

            var thirdRobot = _martianRobotFactory.Create( surface,
                new Vector2( 0, 3 ),
                Direction.West );

            _firstRobotCommands.ForEach( a => firstRobot.Move(a) );
            _secondRobotCommands.ForEach( a => secondRobot.Move(a) );
            _thirdRobotCommands.ForEach( a => thirdRobot.Move(a) );

            Assert.AreEqual( new Vector2(1, 1), firstRobot.Position );
            Assert.AreEqual( Direction.East, firstRobot.Direction );
            Assert.AreEqual( MarsRobotState.Active, firstRobot.State );

            Assert.AreEqual(new Vector2(3, 3), secondRobot.Position);
            Assert.AreEqual(Direction.North, secondRobot.Direction);
            Assert.AreEqual(MarsRobotState.Lost, secondRobot.State);

            Assert.AreEqual(new Vector2(2, 3), thirdRobot.Position);
            Assert.AreEqual(Direction.South, thirdRobot.Direction);
            Assert.AreEqual(MarsRobotState.Active, thirdRobot.State);
        }
    }
}
