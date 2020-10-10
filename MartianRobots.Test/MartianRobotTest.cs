using Common.Contracts;
using MartianRobots.Contracts;
using Moq;
using MoveCoordinator.Contracts;
using NUnit.Framework;

namespace MartianRobots.Test
{
    [TestFixture]
    public class MartianRobotTest
    {
        private MartianRobot _testee;
        private Mock<IMarsSurface> _marsSurfaceMock;
        private Mock<IMoveCoordinator> _moveCoordinatorMock;

        [SetUp]
        public void Setup()
        {
            _marsSurfaceMock = new Mock<IMarsSurface>( MockBehavior.Loose );
            _moveCoordinatorMock = new Mock<IMoveCoordinator>( MockBehavior.Loose );

            _testee = new MartianRobot( _marsSurfaceMock.Object,
                new Vector2(1, 1),
                Direction.North,
                _moveCoordinatorMock.Object );
        }
        [Test]
        public void Move_ThenMoveCoordinatorCalls()
        {
            var moveAction = MoveAction.Forward;

            _moveCoordinatorMock.Setup( mock => mock.Move(
                _marsSurfaceMock.Object,
                _testee,
                moveAction
            ) );

            _testee.Move( MoveAction.Forward );

            _moveCoordinatorMock.Verify(mock => 
                mock.Move(
                    _marsSurfaceMock.Object,
                    _testee,
                    moveAction ),
                Times.Once());
        }
    }
}