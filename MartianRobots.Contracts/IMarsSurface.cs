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
    }
}