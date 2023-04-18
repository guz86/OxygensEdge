using System.Collections;
using Elementary;
using GameEngine;
using GameEngine.Mechanics;
using UnityEngine;

namespace Gameplay.States
{
    public class RotateInDirectionState : StateCoroutine
    {
        
        [SerializeField] private MoveInDirectionEngine _moveEngine;
        [SerializeField] private TransformEngine _transformEngine;
        [SerializeField] private float _rotationSpeed = 60;

        protected override IEnumerator Do()
        {
            var delay = new WaitForFixedUpdate();
            while (true)
            {
                yield return delay;
                this.RotateTransform();
            }
        }

        private void RotateTransform()
        {
            var direction = _moveEngine.Direction;
            _transformEngine.RotateTowardsInDirection(direction, _rotationSpeed, Time.fixedDeltaTime);

        }
    }
}