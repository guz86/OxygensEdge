using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Crafting
{
    public class Component_ActivationKnife: MonoBehaviour, IComponent_ActivationKnife
    {
        [SerializeField]
        private ActivationBehaviour _activationKnife;

        public void Activate()
        {
            _activationKnife.Activate();
        }
        
        public void DeActivate()
        {
            _activationKnife.Deactivate();
        }
    }
}