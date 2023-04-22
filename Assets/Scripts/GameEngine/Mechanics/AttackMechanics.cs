using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class AttackMechanics : MonoBehaviour
    {
        [SerializeField]
        private EventBehaviour attackReceiver;

        [SerializeField]
        private TimerBehaviour countdown;

        [SerializeField]
        private BoolBehaviour isAttack;

        private void OnEnable()
        {
            this.attackReceiver.OnEvent += this.OnAttackRequest;
        }

        private void OnDisable()
        {
            this.attackReceiver.OnEvent -= this.OnAttackRequest;
        }

        private void OnAttackRequest()
        {
            Debug.Log("OnAttackRequest()");
            if (this.isAttack.Value)
            {
                return;
            }
            
            if (this.countdown.IsPlaying)
            {
                return;
            }
            
            // при движении атака не доигрывает и отключается
             isAttack.AssignTrue();
            
            this.countdown.ResetTime();
            this.countdown.Play();
        }
    }
}