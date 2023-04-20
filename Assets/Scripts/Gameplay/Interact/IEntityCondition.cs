using GameEngine.Mechanics;
using Modules.Entities;
using IEntity = GameEngine.Mechanics.IEntity;

namespace Gameplay.Interact
{
    public interface IEntityCondition
    {
        bool IsTrue(IEntity entity);
    }
}