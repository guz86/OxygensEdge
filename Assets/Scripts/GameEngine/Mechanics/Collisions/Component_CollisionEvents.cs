using System;
using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Collisions
{
    public class Component_CollisionEvents : MonoBehaviour, IComponent_CollisionEvents
    {
        public event Action<Collision> OnCollisionEntered
        {
            add { this.eventReceiver.OnCollisionEntered += value; }
            remove { this.eventReceiver.OnCollisionEntered -= value; }
        }

        public event Action<Collision> OnCollisionStaying
        {
            add { this.eventReceiver.OnCollisionStaying += value; }
            remove { this.eventReceiver.OnCollisionStaying -= value; }
        }

        public event Action<Collision> OnCollisionExited
        {
            add { this.eventReceiver.OnCollisionExited += value; }
            remove { this.eventReceiver.OnCollisionExited -= value; }
        }

        [SerializeField]
        private EventBehaviour_Collision eventReceiver;
    }
}