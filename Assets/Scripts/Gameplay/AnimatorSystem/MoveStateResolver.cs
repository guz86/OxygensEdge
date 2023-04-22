using Elementary;
using GameEngine.Mechanics.Move;
using UnityEngine;

namespace Gameplay.AnimatorSystem
{
    public class MoveStateResolver : MonoBehaviour
    {
        [SerializeField] private AnimatorSystem _animator;
        [SerializeField] private MoveInDirectionEngine _moveEngine;
        [SerializeField] private BoolBehaviour _isAttack;


        public void OnEnable()
        {
            _moveEngine.OnStartMove += OnMoveStarted;
            _moveEngine.OnStopMove += OnMoveFinished;
        }

        public void OnDisable()
        {
            _moveEngine.OnStartMove -= OnMoveStarted;
            _moveEngine.OnStopMove -= OnMoveFinished;
        }

        private void OnMoveStarted()
        {
            _animator.SwitchState(AnimatorStateType.MOVE);
        }

        private void OnMoveFinished()
        {
            _isAttack.AssignFalse();
            _animator.SwitchState(AnimatorStateType.IDLE);
        }
    }
}