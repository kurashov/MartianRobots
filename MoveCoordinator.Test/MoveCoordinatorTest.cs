using Common.Contracts;
using MartianRobots.Contracts;
using MoveCoordinator.Contracts;
using MoveCoordinatorV1.Test.Stubs;
using NUnit.Framework;

namespace MoveCoordinatorV1.Test
{
    [TestFixture]
    public class MoveCoordinatorTest
    {
        private IMoveCoordinator _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new MoveCoordinator();
        }
        #region EastDirection

        [Test]
        public void MoveForward_WhenDirectionEast_ThenMoveForward()
        {
            var marsSurface = new MarsSurfaceStub( 5, 3, true );
            var startPosition = new Vector2( 1, 1 );
            var robot = new MartianRobotStub( marsSurface, startPosition, Direction.East );

            _testee.Move( marsSurface, robot, MoveAction.Forward );

            Assert.AreEqual(Direction.East, robot.Direction );
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                new Vector2( startPosition.X + 1, startPosition.Y ),
                robot.Position );
        }

        [Test]
        public void MoveForward_WhenDirectionEastAndRobotOnBoarder_ThenLost()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            var startPosition = new Vector2(4, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.East );

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.East, robot.Direction);
            Assert.AreEqual( startPosition, robot.Position);
            Assert.AreEqual( MarsRobotState.Lost, robot.State );
            Assert.AreEqual( MarsSurfacePointState.WithScent, 
                marsSurface.Surface[4, 1] );
        }

        [Test]
        public void MoveForward_WhenDirectionEastAndRobotOnBoarderButSurfaceWithScent_ThenDoNotMove()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            marsSurface.Surface[4, 1] = MarsSurfacePointState.WithScent;
            var startPosition = new Vector2(4, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.East);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.East, robot.Direction);
            Assert.AreEqual(
                startPosition,
                robot.Position);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[4, 1]);
        }

        [Test]
        public void MoveLeft_WhenDirectionEast_ThenDirectionNorth()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.East);

            _testee.Move(marsSurface, robot, MoveAction.TurnLeft);

            Assert.AreEqual(Direction.North, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }

        [Test]
        public void MoveRight_WhenDirectionEast_ThenDirectionSouth()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.East);

            _testee.Move(marsSurface, robot, MoveAction.TurnRight);

            Assert.AreEqual(Direction.South, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }

        #endregion
        #region SouthDirection
        [Test]
        public void MoveForward_WhenDirectionSouth_ThenMoveForward()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.South);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.South, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                new Vector2(startPosition.X, startPosition.Y - 1),
                robot.Position);
        }

        [Test]
        public void MoveForward_WhenDirectionSouthAndRobotOnBoarder_ThenLost()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            var startPosition = new Vector2(1, 0);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.South);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.South, robot.Direction);
            Assert.AreEqual(startPosition, robot.Position);
            Assert.AreEqual(MarsRobotState.Lost, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[1, 0]);
        }

        [Test]
        public void MoveForward_WhenDirectionSouthAndRobotOnBoarderButSurfaceWithScent_ThenDoNotMove()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            marsSurface.Surface[1, 0] = MarsSurfacePointState.WithScent;
            var startPosition = new Vector2(1, 0);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.South);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.South, robot.Direction);
            Assert.AreEqual(
                startPosition,
                robot.Position);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[1, 0]);
        }

        [Test]
        public void MoveLeft_WhenDirectionSouth_ThenDirectionEast()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.South);

            _testee.Move(marsSurface, robot, MoveAction.TurnLeft);

            Assert.AreEqual(Direction.East, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }

        [Test]
        public void MoveRight_WhenDirectionSouth_ThenDirectionWest()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.South);

            _testee.Move(marsSurface, robot, MoveAction.TurnRight);

            Assert.AreEqual(Direction.West, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }
        #endregion
        #region WestDirection
        [Test]
        public void MoveForward_WhenDirectionWest_ThenMoveForward()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.West);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.West, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                new Vector2(startPosition.X - 1, startPosition.Y),
                robot.Position);
        }

        [Test]
        public void MoveForward_WhenDirectionWestAndRobotOnBoarder_ThenLost()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            var startPosition = new Vector2(0, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.West);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.West, robot.Direction);
            Assert.AreEqual( startPosition, robot.Position);
            Assert.AreEqual(MarsRobotState.Lost, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[0, 1]);
        }

        [Test]
        public void MoveForward_WhenDirectionWestAndRobotOnBoarderButSurfaceWithScent_ThenDoNotMove()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            marsSurface.Surface[0, 1] = MarsSurfacePointState.WithScent;
            var startPosition = new Vector2(0, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.West);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.West, robot.Direction);
            Assert.AreEqual(
                startPosition,
                robot.Position);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[0, 1]);
        }

        [Test]
        public void MoveLeft_WhenDirectionWest_ThenDirectionSouth()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.West);

            _testee.Move(marsSurface, robot, MoveAction.TurnLeft);

            Assert.AreEqual(Direction.South, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }

        [Test]
        public void MoveRight_WhenDirectionWest_ThenDirectionNorth()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.West);

            _testee.Move(marsSurface, robot, MoveAction.TurnRight);

            Assert.AreEqual(Direction.North, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }
        #endregion
        #region NorthDirection
        [Test]
        public void MoveForward_WhenDirectionNorth_ThenMoveForward()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.North);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.North, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                new Vector2(startPosition.X, startPosition.Y + 1),
                robot.Position);
        }

        [Test]
        public void MoveForward_WhenDirectionNorthAndRobotOnBoarder_ThenLost()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            var startPosition = new Vector2(0, 2);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.North);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.North, robot.Direction);
            Assert.AreEqual( startPosition, robot.Position);
            Assert.AreEqual(MarsRobotState.Lost, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[0, 2]);
        }

        [Test]
        public void MoveForward_WhenDirectionNorthAndRobotOnBoarderButSurfaceWithScent_ThenDoNotMove()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, false);
            marsSurface.Surface[0, 2] = MarsSurfacePointState.WithScent;
            var startPosition = new Vector2(0, 2);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.North);

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.North, robot.Direction);
            Assert.AreEqual(
                startPosition,
                robot.Position);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(MarsSurfacePointState.WithScent,
                marsSurface.Surface[0, 2]);
        }

        [Test]
        public void MoveLeft_WhenDirectionNorth_ThenDirectionWest()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.North);

            _testee.Move(marsSurface, robot, MoveAction.TurnLeft);

            Assert.AreEqual(Direction.West, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }

        [Test]
        public void MoveRight_WhenDirectionNorth_ThenDirectionEast()
        {
            var marsSurface = new MarsSurfaceStub(5, 3, true);
            var startPosition = new Vector2(1, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.North);

            _testee.Move(marsSurface, robot, MoveAction.TurnRight);

            Assert.AreEqual(Direction.East, robot.Direction);
            Assert.AreEqual(MarsRobotState.Active, robot.State);
            Assert.AreEqual(
                startPosition,
                robot.Position);
        }
        #endregion
    }
}