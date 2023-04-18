﻿using System;
using Elementary;
using UnityEngine;

namespace Components
{
    public class DeathComponent : MonoBehaviour,
        IDeathComponent
    {
        
        [SerializeField] private EventBehaviour _deathReceiver;
        
        public event Action OnDied
        {
            add => _deathReceiver.OnEvent += value;
            remove => _deathReceiver.OnEvent -= value;
        }
    }
}