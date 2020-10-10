using Common.Contracts;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent martian robot.
    /// </summary>
    public interface IMartianRobot
    {
        IMarsSurface Surface
        {
            get;
        }

        Vector2 Position
        {
            get;
            set;
        }

        Direction Direction
        {
            get;
            set;
        }

        MarsRobotState State
        {
            get;
            set;
        }

        void Move( MoveAction moveAction );
    }
}
