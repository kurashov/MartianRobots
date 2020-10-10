using System.ComponentModel.Composition;
using Common.Contracts;
using MartianRobots.Contracts;

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