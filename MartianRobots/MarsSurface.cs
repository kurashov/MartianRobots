using MartianRobots.Contracts;

namespace MartianRobots
{
    internal class MarsSurface : IMarsSurface
    {
        public MarsSurface( int contRows, int countColumns )
        {
            Surface = new MarsSurfacePointState[contRows, contRows];
        }

        public MarsSurfacePointState[,] Surface { get; }
    }
}