using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class RestoreOxygenPointsMechanics : MonoBehaviour
    {
        [SerializeField] private EventBehaviour _enterFogReceiver;
        [SerializeField] private EventBehaviour _exitFogReceiver;
        [SerializeField] private OxygenPointsEngine _oxygenPoints;
        [SerializeField] private TimerBehaviour _delay;
        [SerializeField] private PeriodBehaviour _restorePeriod;

        private void OnEnable()
        {
            _exitFogReceiver.OnEvent += OnReadyToRestore;
            _delay.OnFinished += OnDelayEnded;
            _restorePeriod.OnPeriodEvent += OnRestoreHitPoints;

            _enterFogReceiver.OnEvent += OnStopToRestore;
        }

        private void OnStopToRestore()
        {
            _restorePeriod.Stop();
            _delay.Stop();
            _delay.ResetTime();
        }

        private void OnDisable()
        {
            _exitFogReceiver.OnEvent -= OnReadyToRestore;
            _delay.OnFinished -= OnDelayEnded;
            _restorePeriod.OnPeriodEvent -= OnRestoreHitPoints;
            
            _enterFogReceiver.OnEvent -= OnStopToRestore;
        }

        private void OnRestoreHitPoints()
        {
            _oxygenPoints.CurrentOxygenPoints += 1;
            if (_oxygenPoints.CurrentOxygenPoints >= _oxygenPoints.MaxOxygenPoints)
            {
                _restorePeriod.Stop();
            }
        }

        private void OnDelayEnded()
        {
            _restorePeriod.Play();
        }

        private void OnReadyToRestore()
        {
            _delay.ResetTime();
            if (!_delay.IsPlaying)
            {
                _delay.Play();
            }

            _restorePeriod.Stop();
        }
    }
}