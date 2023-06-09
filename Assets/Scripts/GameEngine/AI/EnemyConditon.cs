﻿using System;
using Gameplay.Interact;
using Modules.Entities;
using UnityEngine;

namespace GameEngine.AI
{
    [Serializable]
    public sealed class EnemyConditon : IEntityCondition
    {
        [SerializeField]
        private string enemyName = "Hero";
    
        public bool IsTrue(IEntity entity)
        {
            if (!entity.TryGet(out IComponent_GetName nameComponent) || nameComponent.Name != this.enemyName)
            {
                return false;
            }

            // if (!entity.TryGet(out IComponent_IsAlive aliveComponent) || !aliveComponent.IsAlive)
            // {
            //     return false;
            // }
            
            return true;
        }
    }
}