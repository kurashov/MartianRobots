using System;
using System.Composition;
using System.Runtime.CompilerServices;
using MartianRobots.Contracts;

[assembly: InternalsVisibleTo("MartianRobots.Test")]
namespace MartianRobots
{
    [Export(typeof(IMoveCoordinator))]
    public class MoveCoordinator : IMoveCoordinator
    {
        public void Move( IMarsSurface surface, IMartianRobot robot, MoveAction moveAction )
        {
            if( robot.State == MarsRobotState.Lost )
            {
                return;
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

            if ( !surface.InSurface( expectedRobotPosition ) )
            {
                if( surface.Surface[robot.Position.X, robot.Position.Y] 
                    == MarsSurfacePointState.WithScent )
                {
                    //Do nothing
                }
                else
                {
                    surface.Surface[robot.Position.X, robot.Position.Y] =
                        MarsSurfacePointState.WithScent;

                    robot.State = MarsRobotState.Lost;
                    robot.Position = expectedRobotPosition;
                } 
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
            Vector2 shift = new Vector2();
            switch( direction )
            {
                case Direction.East:
                    shift = new Vector2( 1, 0 );
                    break;
                case Direction.North:
                    shift = new Vector2( 0, 1 );
                    break;
                case Direction.South:
                    shift = new Vector2( 0, -1 );
                    break;
                case Direction.West:
                    shift = new Vector2( -1, 0 );
                    break;
                default:
                    throw new ArgumentOutOfRangeException( nameof(direction), direction, null );
            }

            return position + shift;
        }
    }
}