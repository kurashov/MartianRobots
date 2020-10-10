using MartianRobots.Contracts;
using System.Composition;

namespace MartianRobots
{
    [Export(typeof(IMarsSurfaceFactory))]
    public class MarsSurfaceFactory : IMarsSurfaceFactory
    {
        public IMarsSurface Create(Vector2 upperRightCorner)
        {
            return new MarsSurface( upperRightCorner );
        }
    }
}