using System;
using UnityEngine;

namespace Gameplay.GameResources
{
    [Serializable]
    public struct ResourceData
    {
        [SerializeField]
        public ResourceType type;

        [SerializeField]
        public int amount;

        public ResourceData(ResourceType type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }
    }
}