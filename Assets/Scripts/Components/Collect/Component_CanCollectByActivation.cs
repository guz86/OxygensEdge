using Elementary;
using UnityEngine;

namespace Components.Collect
{
    public class Component_CanCollectByActivation : MonoBehaviour, IComponent_CanCollect
    {
        public bool CanCollect
        {
            get { return this.activationController.IsActive; }
        }

        [SerializeField]
        private ActivationBehaviour activationController;
    }
}