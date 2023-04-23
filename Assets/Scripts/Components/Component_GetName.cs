using GameEngine.AI;
using UnityEngine;

namespace Components
{
    public sealed class Component_GetName : MonoBehaviour, IComponent_GetName
    {
        [SerializeField] private string HeroName;
        
        public string Name
        {
            //get { return this.name.Value; }
            get { return HeroName; }
        }

        private readonly IValue<string> name;

        public Component_GetName(IValue<string> name)
        {
            this.name = name;
        }
    }
}