using Elementary;
using UnityEngine;

namespace Gameplay.AnimatorSystem
{
    public class DeathStateResolver : MonoBehaviour
    {
        [SerializeField] private EventBehaviour _isDeath;
        [SerializeField] private AnimatorSystem _animator;

        private static readonly int State = Animator.StringToHash("State");

        private void OnEnable()
        {
            _isDeath.OnEvent += OnStateChanged;
        }

        private void OnDisable()
        {
            _isDeath.OnEvent -= OnStateChanged;
        }

        private void OnStateChanged()
        {
            UpdateState();
        }

        private void UpdateState()
        {
            _animator.SwitchState(AnimatorStateType.DEATH);
        }
    }
}