using Common.Contracts;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent mars surface.
    /// </summary>
    public interface IMarsSurface
    {
        /// <summary>
        /// Gets mars surface matrix.
        /// </summary>
        MarsSurfacePointState[,] Surface
        {
            get;
        }

        /// <summary>
        /// Checks is point inside Surface.
        /// </summary>
        /// <param name="coordinate">point for check</param>
        /// <returns></returns>
        bool InSurface( Vector2 coordinate );
    }
}