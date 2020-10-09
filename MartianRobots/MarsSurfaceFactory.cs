using MartianRobots.Contracts;
using System.Composition;

namespace MartianRobots
{
    [Export(typeof(IMarsSurfaceFactory))]
    public class MarsSurfaceFactory : IMarsSurfaceFactory
    {
        public IMarsSurface Create(int x, int y)
        {
            return new MarsSurface( x, y );
        }
    }
}