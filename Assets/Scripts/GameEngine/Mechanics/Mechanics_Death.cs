using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class Mechanics_Death : MonoBehaviour
    {
        [SerializeField] private HitPointsEngine _hitPoints;
        [SerializeField] private OxygenPointsEngine _oxygenPoints;
        [SerializeField] private EventBehaviour _deathReceiver;


        private void OnEnable()
        {
            this._hitPoints.OnHitPointsEmpty += OnPointsEmpty;
            this._oxygenPoints.OnOxygenPointsEmpty += OnPointsEmpty;
        }

        private void OnDisable()
        {
            this._hitPoints.OnHitPointsEmpty -= OnPointsEmpty;
            this._oxygenPoints.OnOxygenPointsEmpty -= OnPointsEmpty;
        }

        private void OnPointsEmpty()
        { 
            _deathReceiver.Call();
        }
    }
}