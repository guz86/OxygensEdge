using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public class EventObserver_PlayAnimation : AbstractEventObserver
    {

        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationName;

        protected override void OnEvent(int value)
        {
            _animator.Play(stateName:_animationName, layer:-1, normalizedTime: 0);
        }
    }
}

