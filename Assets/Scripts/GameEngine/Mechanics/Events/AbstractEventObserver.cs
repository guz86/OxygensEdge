using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public abstract class AbstractEventObserver : MonoBehaviour
    {
        [SerializeField] private EventBehaviour_Int _receiver;

        private void OnEnable()
        {
            _receiver.OnEvent += OnEvent;
        }

        private void OnDisable()
        {
            _receiver.OnEvent += OnEvent;
        }

        protected abstract void OnEvent(int value);
    }
}