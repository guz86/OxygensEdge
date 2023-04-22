using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public class AnimationEventObserver_CallEvent : MonoBehaviour
    {
        [SerializeField] private EventBehaviour eventReceiver;

        private void Call()
        {
            Debug.Log("AnimationEventObserver_CallEvent Call()");
            eventReceiver.Call();
        }

    }
}