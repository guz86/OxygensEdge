using System;
using GameEngine.Mechanics;
using UnityEngine;

namespace Components
{
    public class OxygenPointsComponent : MonoBehaviour,
        IOxygenPointsComponent
    {
        [SerializeField] private OxygenPointsEngine _oxyPoints;

        public event Action<int> OnOxygenPointsChanged
        {
            add => _oxyPoints.OnOxygenPointsChanged += value;
            remove => _oxyPoints.OnOxygenPointsChanged -= value;
        }

        public int OxygenPoints
        {
            get { return _oxyPoints.CurrentOxygenPoints; }
        }

        public int MaxOxygenPoints
        {
            get { return _oxyPoints.MaxOxygenPoints; }
        }


        public void SetOxygenPoints(int hitPoints)
        {
            _oxyPoints.CurrentOxygenPoints = hitPoints;
        }

        public void SetMaxOxygenPoints(int hitPoints)
        {
            _oxyPoints.MaxOxygenPoints = hitPoints;
        }
        
        public void FullOxygenPoints()
        {
            _oxyPoints.CurrentOxygenPoints = _oxyPoints.MaxOxygenPoints;
        }
    }
}