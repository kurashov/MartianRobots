namespace MartianRobots.Contracts
{
    public interface IMartianRobotFactory
    {
        IMartianRobot Create( IMarsSurface surface, Vector2 startPosition, Direction startDirection );
    }
}
