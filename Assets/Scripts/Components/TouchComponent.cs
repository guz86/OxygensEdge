using Elementary;
using UnityEngine;

namespace Components
{
    public class TouchComponent : MonoBehaviour, ITouchComponent
    {
        [SerializeField] private EventBehaviour _inTouchReceiver;
        
        public void OnTouch()
        {
            _inTouchReceiver.Call();
        }
    }
}