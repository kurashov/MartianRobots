using System;
using System.Numerics;
using MartianRobots.Contracts;

namespace MartianRobots
{
    internal class MoveCoordinator : IMoveCoordinator
    {
        public void Move( IMarsSurface surface, IMartianRobot robot, MoveAction moveAction )
        {
            if( robot.State == MarsRobotState.Lost )
            {
                throw new ArgumentException( nameof(robot) );
            }

            switch( moveAction )
            {
                case MoveAction.Forward:
                    MoveForward( surface, robot );
                    break;
                case MoveAction.TurnLeft:
                    TurnLeft( robot );
                    break;
                case MoveAction.TurnRight:
                    TurnRight( robot );
                    break;
                default:
                    throw new ArgumentOutOfRangeException( nameof(moveAction), moveAction, null );
            }

        }

        private void MoveForward( IMarsSurface surface, IMartianRobot robot )
        {
            var expectedRobotPosition = CalculatePosition(
                robot.Position,
                robot.Direction);
            //TODO check this place
            if (expectedRobotPosition.X < 0 ||
                expectedRobotPosition.Y < 0 ||
                expectedRobotPosition.X > surface.Surface.Rank ||
                expectedRobotPosition.Y > surface.Surface.Length )
            {
                robot.State = MarsRobotState.Lost;
                surface.Surface[(int)expectedRobotPosition.X, (int)expectedRobotPosition.Y] =
                    MarsSurfacePointState.WithScent;
            }
            else
            {
                robot.Position = expectedRobotPosition;
            }
        }

        private void TurnRight(IMartianRobot robot)
        {
            switch (robot.Direction)
            {
                case Direction.North:
                    robot.Direction = Direction.East;
                    break;
                case Direction.South:
                    robot.Direction = Direction.West;
                    break;
                case Direction.East:
                    robot.Direction = Direction.South;
                    break;
                case Direction.West:
                    robot.Direction = Direction.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(robot.Direction));
            }
        }

        private void TurnLeft( IMartianRobot robot )
        {
            switch( robot.Direction )
            {
                case Direction.North:
                    robot.Direction = Direction.West;
                    break;
                case Direction.South:
                    robot.Direction = Direction.East;
                    break;
                case Direction.East:
                    robot.Direction = Direction.North;
                    break;
                case Direction.West:
                    robot.Direction = Direction.South;
                    break;
                default:
                    throw new ArgumentOutOfRangeException( nameof(robot.Direction) );
            }
        }

        private Vector2 CalculatePosition( Vector2 position, Direction direction )
        {
            switch( direction )
            {
                case Direction.East:
                    return new Vector2( position.X + 1, position.Y );
                case Direction.North:
                    return new Vector2( position.X, position.Y + 1 );
                case Direction.South:
                    return new Vector2( position.X, position.Y - 1 );
                case Direction.West:
                    return new Vector2( position.X - 1, position.Y );
                default:
                    throw new ArgumentOutOfRangeException( nameof(direction), direction, null );
            }
        }
    }
}