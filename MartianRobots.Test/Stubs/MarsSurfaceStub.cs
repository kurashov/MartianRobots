using MartianRobots.Contracts;

namespace MartianRobots.Test.Stubs
{
    internal class MarsSurfaceStub : IMarsSurface
    {
        private readonly bool _inSurfaceResult;

        public MarsSurfaceStub(int m, int n, bool inSurfaceResult)
        {
            _inSurfaceResult = inSurfaceResult;
            Surface = new MarsSurfacePointState[m,n];
        }

        public MarsSurfacePointState[,] Surface { get; }

        public bool InSurface( Vector2 coordinate )
        {
            return _inSurfaceResult;
        }
    }
}
