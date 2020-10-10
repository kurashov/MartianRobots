using System.ComponentModel.Composition;
using Common.Contracts;
using MartianRobots.Contracts;
using MoveCoordinator.Contracts;

namespace MartianRobots
{
    [Export(typeof(IMartianRobotFactory))]
    public class MartianRobotFactory : IMartianRobotFactory
    {
        private readonly IMoveCoordinator _moveCoordinator;

        [ImportingConstructor]
        public MartianRobotFactory( IMoveCoordinator moveCoordinator )
        {
            _moveCoordinator = moveCoordinator;
        }

        public IMartianRobot Create( IMarsSurface surface, Vector2 startPosition, Direction startDirection)
        {
            return new MartianRobot(surface,
                startPosition,
                startDirection,
                _moveCoordinator );
        }
    }
}
