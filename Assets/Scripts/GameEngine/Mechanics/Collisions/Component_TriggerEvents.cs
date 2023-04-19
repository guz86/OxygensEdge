using System;
using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Collisions
{
    public class Component_TriggerEvents : MonoBehaviour, IComponent_TriggerEvents
    {
        public event Action<Collider> OnEntered
        {
            add { this.eventReceiver.OnTriggerEntered += value; }
            remove { this.eventReceiver.OnTriggerEntered -= value; }
        }

        public event Action<Collider> OnStaying
        {
            add { this.eventReceiver.OnTriggerStaying += value; }
            remove { this.eventReceiver.OnTriggerStaying -= value; }
        }

        public event Action<Collider> OnExited
        {
            add { this.eventReceiver.OnTriggerExited += value; }
            remove { this.eventReceiver.OnTriggerExited -= value; }
        }

        [SerializeField]
        private EventBehaviour_Trigger eventReceiver;
    }
}