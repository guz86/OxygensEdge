using Elementary;
using UnityEngine;

namespace GameEngine.Crafting
{
    public class Component_ActivationKnife: MonoBehaviour, IComponent_ActivationKnife
    {
        [SerializeField]
        private ActivationBehaviour activationKnife;

        public void Activate()
        {
            activationKnife.Activate();
        }
    }
}