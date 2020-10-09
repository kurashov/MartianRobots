using MartianRobots.Contracts;

namespace MartianRobots.Test
{
    internal class MarsSurfaceStub : IMarsSurface
    {
        public MarsSurfaceStub(int m, int n)
        {
            Surface = new MarsSurfacePointState[m,n];
        }
        public MarsSurfacePointState[,] Surface { get; }
    }
}
