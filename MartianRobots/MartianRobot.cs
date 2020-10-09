using System.Numerics;
using MartianRobots.Contracts;

namespace MartianRobots
{
    public class MartianRobot : IMartianRobot
    {
        private readonly IMoveCoordinator _moveCoordinator;

        internal MartianRobot( IMarsSurface surface,
            Vector2 position,
            Direction direction,
            IMoveCoordinator moveCoordinator )
        {
            _moveCoordinator = moveCoordinator;
            Surface = surface;
            Position = position;
            Direction = direction;
        }

        public Vector2 Position { get; set; }
        public Direction Direction { get; set; }
        public MarsRobotState State
        {
            get;
            set;
        }
        public IMarsSurface Surface { get; }

        public void Move(MoveAction moveAction)
        {
            _moveCoordinator.Move( Surface, this, moveAction );
        }
    }
}
