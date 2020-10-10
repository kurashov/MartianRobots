using Common.Contracts;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent martian robot.
    /// </summary>
    public interface IMartianRobot
    {
        /// <summary>
        /// Gets surface in which located robot.
        /// </summary>
        IMarsSurface Surface
        {
            get;
        }

        /// <summary>
        /// Robot current position.
        /// </summary>
        Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// Robot current direction.
        /// </summary>
        Direction Direction
        {
            get;
            set;
        }

        /// <summary>
        /// Robot current state.
        /// </summary>
        MarsRobotState State
        {
            get;
            set;
        }

        /// <summary>
        /// Move robot according to move action.
        /// </summary>
        /// <param name="moveAction">Represent in direction should moves robot.</param>
        void Move( MoveAction moveAction );
    }
}
