using System.Numerics;
using MartianRobots.Contracts;

namespace MartianRobots
{
    internal class MartianRobot : IMartianRobot
    {
        public MartianRobot( Vector2 position,
            Direction direction, 
            MarsRobotState state )
        {
            Position = position;
            Direction = direction;
            State = state;
        }

        public Vector2 Position { get; set; }
        public Direction Direction { get; set; }
        public MarsRobotState State { get; set; }
    }
}
