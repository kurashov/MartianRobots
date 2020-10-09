namespace MartianRobots.Contracts
{
    public interface IMarsSurfaceFactory
    {
        IMarsSurface Create( int x, int y );
    }
}