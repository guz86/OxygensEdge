using GameEngine.Mechanics;
using Modules.Entities;
using Sirenix.OdinInspector;
using IEntity = GameEngine.Mechanics.IEntity;

#if ODIN_INSPECTOR

#else
using UnityEngine;
#endif

namespace Gameplay.Interact
{
#if ODIN_INSPECTOR
    public abstract class ScriptableEntityCondition : SerializedScriptableObject, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
#else
    public abstract class ScriptableEntityCondition : ScriptableObject, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
#endif
}