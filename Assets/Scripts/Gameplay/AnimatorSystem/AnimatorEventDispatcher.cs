using System;
using UnityEngine;

namespace Gameplay.AnimatorSystem
{
    public class AnimatorEventDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            this.OnEventReceived?.Invoke(key);
        }
    }
}