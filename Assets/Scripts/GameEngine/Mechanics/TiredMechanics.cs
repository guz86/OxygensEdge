/*using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{

    public class TiredMechanics : MonoBehaviour
    {
        [SerializeField] private EventBehaviour _attack;
        [SerializeField] private OxygenPointsEngine _oxygenPointsEngine;

        
        private void OnEnable()
        {
            _attack.OnEvent += OnTired;
        }

        private void OnDisable()
        {
            _attack.OnEvent -= OnTired;
        }

        private void OnTired()
        {
            if (_oxygenPointsEngine.CurrentOxygenPoints == _oxygenPointsEngine.MaxOxygenPoints)
            {
                _oxygenPointsEngine.CurrentOxygenPoints = _oxygenPointsEngine.MaxOxygenPoints / 2;
            }
            
            if (_oxygenPointsEngine.CurrentOxygenPoints > _oxygenPointsEngine.MaxOxygenPoints / 2)
            {
                _oxygenPointsEngine.CurrentOxygenPoints = _oxygenPointsEngine.MaxOxygenPoints / 3;
            }
        }
    }
}*/