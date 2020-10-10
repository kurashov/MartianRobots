using System;
using System.Runtime.CompilerServices;
using Common.Contracts;
using MartianRobots.Contracts;

namespace ConsoleApplication.Extensions
{
    internal static class ApplicationExtensions
    {
        public static Direction ToDirection( this string direction )
        {
            switch( direction )
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.South;
                case "W":
                    return Direction.West;
                case "S":
                    return Direction.South;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string ToOutput( this Direction direction )
        {
            switch( direction )
            {
                case Direction.East:
                    return "E";
                case Direction.North:
                    return "N";
                case Direction.South:
                    return "S";
                case Direction.West:
                    return "W";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static MoveAction ToMoveAction( this char action )
        {
            switch( action )
            {
                case 'F':
                    return MoveAction.Forward;
                case 'L':
                    return MoveAction.TurnLeft;
                case 'R':
                    return MoveAction.TurnRight;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
