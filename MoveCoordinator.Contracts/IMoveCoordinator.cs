using Common.Contracts;
using MartianRobots.Contracts;

namespace MoveCoordinator.Contracts
{
    public interface IMoveCoordinator
    {
        void Move( IMarsSurface surface, IMartianRobot robot, MoveAction moveAction );
    }
}