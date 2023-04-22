using Elementary;
using UnityEngine;

namespace GameEngine.Crafting
{
    public class Component_ActivationSword: MonoBehaviour, IComponent_ActivationSword
    {
        [SerializeField]
        private ActivationBehaviour _activationSword;

        public void Activate()
        {
            _activationSword.Activate();
        }
        
        public void DeActivate()
        {
            _activationSword.Deactivate();
        }
    }
}