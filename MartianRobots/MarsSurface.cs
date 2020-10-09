using MartianRobots.Contracts;

namespace MartianRobots
{
    public class  MarsSurface : IMarsSurface
    {
        internal MarsSurface( int contRows, int countColumns )
        {
            Surface = new MarsSurfacePointState[contRows, countColumns];
        }
 
        public MarsSurfacePointState[,] Surface { get; }
    }
}