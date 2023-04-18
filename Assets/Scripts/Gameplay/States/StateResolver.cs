using GameEngine;
using UnityEngine;

namespace Gameplay.States
{
    public class StateResolver : MonoBehaviour
    {
        [SerializeField] private HeroStateMachine _stateMachine;
        [SerializeField] private MoveInDirectionEngine _moveEngine;


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
            _stateMachine.SwitchState(HeroStateType.MOVE);
        }

        private void OnMoveFinished()
        {
            _stateMachine.SwitchState(HeroStateType.IDLE);
        }
    }
}