﻿using System;
using Common.Contracts;
using MartianRobots.Contracts;

namespace MoveCoordinatorV1.Test.Stubs
{
    internal class MartianRobotStub : IMartianRobot
    {
        internal MartianRobotStub(IMarsSurface surface,
            Vector2 position,
            Direction direction )
        {
            Surface = surface;
            Position = position;
            Direction = direction;
        }

        public Vector2 Position { get; set; }
        public Direction Direction { get; set; }
        public MarsRobotState State { get; set; }
        public IMarsSurface Surface { get; }

        public void Move(MoveAction moveAction)
        {
            throw new NotImplementedException();
        }
    }
}
