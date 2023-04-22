using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class TakeDamage : MonoBehaviour
    {
        [SerializeField] private EventBehaviour_Int _takeDamageReceiver;
        [SerializeField] private HitPointsEngine _hitPoints; 
        

        private void OnEnable()
        {
            this._takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this._takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            this._hitPoints.CurrentHitPoints -= damage;
        }
    }
}