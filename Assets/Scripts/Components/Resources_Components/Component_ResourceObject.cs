using Gameplay.GameResources;
using UnityEngine;

namespace Components.Resources_Components
{
    public sealed class Component_ResourceObject : MonoBehaviour,
        IComponent_GetResourceType,
        IComponent_GetResourceCount
    {
        public ResourceType Type
        {
            get { return this.info.type; }
        }

        public int Count
        {
            get { return this.info.count; }
        }
        
        [SerializeField]
        private ScriptableResourceObject info;
    }
}