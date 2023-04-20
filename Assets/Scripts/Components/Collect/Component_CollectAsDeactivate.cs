using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components.Collect
{
    public class Component_CollectAsDeactivate : MonoBehaviour, IComponent_Collect
    {
        [Space]
        [SerializeField]
        private ActivationBehaviour collectReceiver;
        
        [Button]
        [GUIColor(0, 1, 0)]
        public void Collect()
        {
            this.collectReceiver.Deactivate();
        }
    }
}