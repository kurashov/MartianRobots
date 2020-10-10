using System.Collections.Generic;
using Common.Contracts;

namespace ConsoleApplication.InputData
{
    internal class ApplicationInput
    {
        public ApplicationInput()
        {
            Robots = new List<RobotInput>();
        }

        public Vector2 SurfaceDimension
        {
            get;
            set;
        }

        public List<RobotInput> Robots
        {
            get;
        }
    }
}
