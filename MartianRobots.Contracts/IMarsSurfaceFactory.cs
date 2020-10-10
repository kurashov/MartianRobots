using Common.Contracts;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent factory for creating surface.
    /// </summary>
    public interface IMarsSurfaceFactory
    {
        /// <summary>
        /// Create mars surface.
        /// </summary>
        /// <param name="upperRightCorner">upper right surface corner.</param>
        /// <returns></returns>
        IMarsSurface Create(Vector2 upperRightCorner);
    }
}