using System;
using UnityEngine;

namespace GameEngine.Mechanics.Collisions
{
    public interface IComponent_CollisionEvents
    {
        event Action<Collision> OnCollisionEntered;

        event Action<Collision> OnCollisionStaying;

        event Action<Collision> OnCollisionExited;
    }
}