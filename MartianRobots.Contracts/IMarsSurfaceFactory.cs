using Common.Contracts;

namespace MartianRobots.Contracts
{
    public interface IMarsSurfaceFactory
    {
        IMarsSurface Create(Vector2 upperRightCorner);
    }
}