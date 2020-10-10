using Common.Contracts;

namespace MartianRobots.Contracts
{
    /// <summary>
    /// Represent factory which created robots.
    /// </summary>
    public interface IMartianRobotFactory
    {
        /// <summary>
        /// Create robot.
        /// </summary>
        /// <param name="surface">Surface in which located robot.</param>
        /// <param name="startPosition">Robot start position.</param>
        /// <param name="startDirection">Robot start direction.</param>
        /// <returns></returns>
        IMartianRobot Create( IMarsSurface surface, Vector2 startPosition, Direction startDirection );
    }
}
