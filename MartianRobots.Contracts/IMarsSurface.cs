using Common.Contracts;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent mars surface.
    /// </summary>
    public interface IMarsSurface
    {
        MarsSurfacePointState[,] Surface
        {
            get;
        }

        bool InSurface( Vector2 coordinate );
    }
}