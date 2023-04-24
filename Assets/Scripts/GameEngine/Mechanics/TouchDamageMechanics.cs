using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class TouchDamageMechanics : MonoBehaviour
    {
        [SerializeField] private EventBehaviour _enterTouchReceiver;
        [SerializeField] private HitPointsEngine _hitPoints;

        private void OnEnable()
        {
            _enterTouchReceiver.OnEvent += OnTouchHit;
        }

        private void OnTouchHit()
        {
            _hitPoints.CurrentHitPoints -= 1;
        }

        private void OnDisable()
        {
            _enterTouchReceiver.OnEvent -= OnTouchHit;
        }
    }
}