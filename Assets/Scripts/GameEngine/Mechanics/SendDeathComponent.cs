using System;
using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class SendDeathComponent : MonoBehaviour, ISendDeathComponent
    {
        [SerializeField] private EventBehaviour _deathReceiver;
        
        public event Action OnDied;
        
        public void Die()
        {
            _deathReceiver.Call();
            OnDied?.Invoke();
        }
    }
}