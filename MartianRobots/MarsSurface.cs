using System.Runtime.CompilerServices;
using Common.Contracts;
using MartianRobots.Contracts;

[assembly: InternalsVisibleTo("MartianRobots.Test")]
namespace MartianRobots
{
    internal class MarsSurface : IMarsSurface
    {
        internal MarsSurface( Vector2 upperRightCorner )
        {
            Surface = new MarsSurfacePointState[upperRightCorner.X + 1, upperRightCorner.Y + 1];
        }
 
        public MarsSurfacePointState[,] Surface { get; }
        public bool InSurface( Vector2 coordinate )
        {
            return coordinate.X >= 0
                && coordinate.Y >= 0
                && coordinate.X < Surface.GetLength( 0 )
                && coordinate.Y < Surface.GetLength( 1 );
        }
    }
}