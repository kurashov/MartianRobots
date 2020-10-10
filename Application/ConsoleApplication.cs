using System;
using System.ComponentModel.Composition;
using System.IO;
using Application.Contract;
using Common.Contracts;
using ConsoleApplication.Extensions;
using ConsoleApplication.InputData;
using MartianRobots.Contracts;

namespace ConsoleApplication
{
    [Export(typeof(IApplication))]
    internal class ConsoleApplication : IApplication
    {
        private readonly IMarsSurfaceFactory _marsSurfaceFactory;
        private readonly IMartianRobotFactory _martianRobotFactory;

        [ImportingConstructor]
        public ConsoleApplication( IMarsSurfaceFactory marsSurfaceFactory,
            IMartianRobotFactory martianRobotFactory )
        {
            _marsSurfaceFactory = marsSurfaceFactory;
            _martianRobotFactory = martianRobotFactory;
        }

        public void Run()
        {
            try
            {
                var applicationInput = ReadApplicationInput();

                var surface = _marsSurfaceFactory.Create(applicationInput.SurfaceDimension);

                foreach (var robotInput in applicationInput.Robots)
                {
                    var robot = _martianRobotFactory.Create(
                        surface,
                        robotInput.StartPosition,
                        robotInput.Direction);

                    robotInput.Commands.ForEach(c => robot.Move(c));

                    Console.WriteLine($"{robot.Position.X} {robot.Position.Y} " +
                        $"{robot.Direction.ToOutput()} " +
                        $"{(robot.State == MarsRobotState.Lost ? "LOST" : null)}");
                }
            }
            catch( InvalidDataException )
            {
                Console.WriteLine( "Error in input data format. Try again." );
                Run();
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
                Console.WriteLine( "Unexpected error. Try again." );
                Run();
            }
        }

        private ApplicationInput ReadApplicationInput()
        {
            var result = new ApplicationInput
            {
                SurfaceDimension = ReadSurfaceDimension()
            };

            while ( true )
            {
                var robotInput = ReadRobotInput();
                if( robotInput == null )
                {
                    break;
                }
                result.Robots.Add( robotInput );
            }

            return result;
        }

        private Vector2 ReadSurfaceDimension()
        {
            var tokens = Console
                .ReadLine()?
                .Split();

            if (tokens?.Length != 2)
            {
                throw new InvalidDataException();
            }

            return new Vector2(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        private RobotInput ReadRobotInput()
        {
            var result = new RobotInput();

            var inputLine = Console.ReadLine();

            if( string.IsNullOrEmpty( inputLine ) )
            {
                return null;
            }

            var tokens = inputLine.Split();

            if( tokens.Length != 3 )
            {
                throw new InvalidDataException();
            }

            result.StartPosition = new Vector2( int.Parse( tokens[0] ), int.Parse( tokens[1] ) );
            result.Direction = tokens[2].ToDirection();

            var commands = Console.ReadLine();

            if( commands != null )
            {
                foreach (var command in commands)
                {
                    result.Commands.Add( command.ToMoveAction() );
                }
            }

            return result;
        }
    }
}
