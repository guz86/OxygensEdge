using Modules.Entities;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class EntityProxy : MonoBehaviour, IEntityProxy
    {
        [SerializeField] private UnityEntityBase _entity;
        
        public T Get<T>()
        {
            return this._entity.Get<T>();
        }
        public bool TryGet<T>(out T element)
        {
            return this._entity.TryGet(out element);
        }
    }
}