using System.Numerics;
using MartianRobots.Contracts;
using Moq;
using NUnit.Framework;

namespace MartianRobots.Test
{
    public class Tests
    {
        private IMoveCoordinator _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new MoveCoordinator();
        }

        [Test]
        public void MoveForward_WhenDirectionEast_ThenMoveForward()
        {
            var marsSurface = new MarsSurfaceStub( 5, 3 );
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
        public void MoveForward_WhenDirectionEastAndRobotOnBoarder_ThenMoveForward()
        {
            var marsSurface = new MarsSurfaceStub(5, 3);
            var startPosition = new Vector2(4, 1);
            var robot = new MartianRobotStub(marsSurface, startPosition, Direction.East );

            _testee.Move(marsSurface, robot, MoveAction.Forward);

            Assert.AreEqual(Direction.East, robot.Direction);
            Assert.AreEqual(
                new Vector2(startPosition.X + 1, startPosition.Y),
                robot.Position);
            Assert.AreEqual( MarsRobotState.Lost, robot.State );
            Assert.AreEqual( MarsSurfacePointState.WithScent, 
                marsSurface.Surface[4, 1] );
        }
    }
}