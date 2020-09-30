namespace MartianRobots.Contracts
{
    public interface IMoveCoordinator
    {
        void Move(  IMarsSurface surface, IMartianRobot robot, MoveAction moveAction );
    }
}