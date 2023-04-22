using Elementary;
using UnityEngine;

namespace Gameplay.AnimatorSystem
{
//public class BoolObserver_ChangeAnimatorState : MonoBehaviour
    public class AttackStateResolver : MonoBehaviour
    {
        [SerializeField] private BoolBehaviour _isAttack;
        [SerializeField] private AnimatorSystem _animator;
        [SerializeField] private ActivationBehaviour _knifeItem;
        [SerializeField] private ActivationBehaviour _swordItem;
        
        
        private static readonly int State = Animator.StringToHash("State");

        private void Awake()
        {
            this.UpdateState(_isAttack.Value);
        }
        
        private void OnEnable()
        {
            _isAttack.OnValueChanged += OnStateChanged;
        }

        private void OnDisable()
        {
            _isAttack.OnValueChanged -= OnStateChanged;
        }

        private void OnStateChanged(bool isTrue)
        {
            UpdateState(isTrue);
        }
        
        private void UpdateState(bool isTrue)
        {
            if (isTrue && (_knifeItem || _swordItem))
            {
                //_animator.SetInteger(State, 3);
                _animator.SwitchState(AnimatorStateType.MELEE_COMBAT);
            }
            else
            {
                // _animator.SetInteger(State, 0);
                _animator.SwitchState(AnimatorStateType.IDLE);
            }
        }
    }
}
