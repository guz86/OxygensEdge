using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class SplashHitMechanics : MonoBehaviour
    {
        [SerializeField]
        private EventBehaviour hitReceiver;

        [SerializeField]
        private SplashDamageEngine damageEngine;

        private void OnEnable()
        {
            this.hitReceiver.OnEvent += this.OnHit;
        }

        private void OnDisable()
        {
            this.hitReceiver.OnEvent -= this.OnHit;
        }

        private void OnHit()
        {
            Debug.Log("SplashHitMechanics OnHit()" );

            this.damageEngine.DealDamage();
        }
    }
}