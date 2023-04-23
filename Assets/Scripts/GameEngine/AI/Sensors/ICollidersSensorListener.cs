using UnityEngine;

namespace GameEngine.AI.Sensors
{
    public interface ICollidersSensorListener
    {
        void OnCollidersUpdated(Collider[] buffer, int size);
    }
}