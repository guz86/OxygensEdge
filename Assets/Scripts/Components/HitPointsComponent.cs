using System;
using GameEngine.Mechanics;
using UnityEngine;

namespace Components
{
    public class HitPointsComponent : MonoBehaviour,
        IHitPointsComponent
    {
        [SerializeField] private HitPointsEngine _hitPoints;

        public event Action<int> OnHitPointsChanged
        {
            add => _hitPoints.OnHitPointsChanged += value;
            remove => _hitPoints.OnHitPointsChanged -= value;
        }

        public int HitPoints
        {
            get { return _hitPoints.CurrentHitPoints; }
        }     
        
        public int MaxHitPoints
        {
            get { return _hitPoints.MaxHitPoints; }
        }
        

        public void SetHitPoints(int hitPoints)
        {
            _hitPoints.CurrentHitPoints = hitPoints;
        }

        public void SetMaxHitPoints(int hitPoints)
        {
            _hitPoints.MaxHitPoints = hitPoints;
        }
        
    }
}