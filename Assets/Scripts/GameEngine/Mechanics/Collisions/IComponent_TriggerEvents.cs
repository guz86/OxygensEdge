using System;
using UnityEngine;

namespace GameEngine.Mechanics.Collisions
{
    public interface IComponent_TriggerEvents
    {
        event Action<Collider> OnEntered;

        event Action<Collider> OnStaying; 

        event Action<Collider> OnExited;
    }
}