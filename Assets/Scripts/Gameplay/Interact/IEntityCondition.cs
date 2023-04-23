using Modules.Entities;

namespace Gameplay.Interact
{
    public interface IEntityCondition
    {
        bool IsTrue(IEntity entity);
    }
}