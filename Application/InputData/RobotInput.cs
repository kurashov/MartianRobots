using System.Collections.Generic;
using Common.Contracts;
using MartianRobots.Contracts;

namespace ConsoleApplication.InputData
{
    internal class RobotInput
    {
        public RobotInput()
        {
            Commands = new List<MoveAction>();
        }

        public Vector2 StartPosition
        {
            get;
            set;
        }

        public Direction Direction
        {
            get;
            set;
        }

        public List<MoveAction> Commands
        {
            get;
        }
    }
}