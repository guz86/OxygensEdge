using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public class AnimationEventObserver_SwitchToggle : MonoBehaviour
    {
        [SerializeField] private BoolBehaviour _toogle;

        private void SetFalse()
        {
            _toogle.AssignFalse();
        }
    }
}