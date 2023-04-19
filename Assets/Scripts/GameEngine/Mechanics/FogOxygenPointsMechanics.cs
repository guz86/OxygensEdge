using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class FogOxygenPointsMechanics : MonoBehaviour
    {
        [SerializeField] private EventBehaviour _enterFogReceiver;
        [SerializeField] private EventBehaviour _exitFogReceiver;
        [SerializeField] private OxygenPointsEngine _oxygenPoints;
        [SerializeField] private TimerBehaviour _delay;
        [SerializeField] private PeriodBehaviour _restorePeriod;

        private void OnEnable()
        {
            _enterFogReceiver.OnEvent += OnOxygenHit;
            _delay.OnFinished += OnDelayEnded;
            _restorePeriod.OnPeriodEvent += OnReduceOxygenPoints;
            
            _exitFogReceiver.OnEvent += OnOxygenStopHit;
            
        }

        private void OnOxygenStopHit()
        {
            _restorePeriod.Stop();
            _delay.Stop();
            _delay.ResetTime();
        }

        private void OnDisable()
        {
            
            _exitFogReceiver.OnEvent -= OnOxygenStopHit;
            
            _enterFogReceiver.OnEvent -= OnOxygenHit;
            _delay.OnFinished -= OnDelayEnded;
            _restorePeriod.OnPeriodEvent -= OnReduceOxygenPoints;
        }

        private void OnReduceOxygenPoints()
        {
            _oxygenPoints.CurrentOxygenPoints -= 1;

            
            if (_oxygenPoints.CurrentOxygenPoints == 0)
            {
                _restorePeriod.Stop();
            }
        }

        private void OnDelayEnded()
        {
            _restorePeriod.Play();
        }

        private void OnOxygenHit()
        {
            if (!_delay.IsPlaying)
            {
                _delay.Play();
            }
        }
    }
}