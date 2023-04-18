using System;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class OxygenPointsEngine : MonoBehaviour
    {
        [SerializeField] private int _maxOxygenPoints;

        [SerializeField] private int _currentOxygenPoints;

        public event Action OnSetuped;

        public event Action<int> OnOxygenPointsChanged;

        public event Action<int> OnMaxOxygenPointsChanged;

        public event Action OnOxygenPointsFull;

        public event Action OnOxygenPointsEmpty;

        public int CurrentOxygenPoints
        {
            get { return _currentOxygenPoints; }
            set { SetOxygenPoints(value); }
        }

        public int MaxOxygenPoints
        {
            get { return _maxOxygenPoints; }
            set { SetMaxOxygenPoints(value); }
        }

        public void Setup(int current, int max)
        {
            _maxOxygenPoints = max;
            _currentOxygenPoints = Mathf.Clamp(current, 0, _maxOxygenPoints);
            OnSetuped?.Invoke();
        }

        private void SetOxygenPoints(int value)
        {
            
            value = Mathf.Clamp(value, 0, _maxOxygenPoints);
            _currentOxygenPoints = value;
            OnOxygenPointsChanged?.Invoke(_currentOxygenPoints);

            if (value <= 0)
            {
                this.OnOxygenPointsEmpty?.Invoke();
            }

            if (value >= _maxOxygenPoints)
            {
                this.OnOxygenPointsFull?.Invoke();
            }
        }

        private void SetMaxOxygenPoints(int value)
        {
            value = Math.Max(1, value);
            if (_currentOxygenPoints > value)
            {
                _currentOxygenPoints = value;
            }

            _maxOxygenPoints = value;
            OnMaxOxygenPointsChanged?.Invoke(value);
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            _maxOxygenPoints = Math.Max(1, _maxOxygenPoints);
            _currentOxygenPoints = Mathf.Clamp(_currentOxygenPoints, 1, _maxOxygenPoints);
        }
#endif
    }
}