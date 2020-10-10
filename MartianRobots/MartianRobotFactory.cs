using System.Composition;
using MartianRobots.Contracts;

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
