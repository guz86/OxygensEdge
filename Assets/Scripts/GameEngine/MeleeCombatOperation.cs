using Modules.Entities;
using Sirenix.OdinInspector;

namespace GameEngine
{
    public sealed class MeleeCombatOperation
    {
        [ShowInInspector]
        public IEntity targetEntity;

        [ReadOnly]
        [ShowInInspector]
        public bool targetDestroyed;

        public MeleeCombatOperation(IEntity target)
        {
            this.targetEntity = target;
        }

        public MeleeCombatOperation()
        {
        }
    }
}