using System;
using System.Numerics;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent martian robot.
    /// </summary>
    public interface IMartianRobot
    {
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
    }
}
