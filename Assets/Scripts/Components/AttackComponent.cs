using Elementary;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour, IAttackComponent
    {
        [SerializeField] private EventBehaviour _attackReceiver;

        public void Attack()
        {
            _attackReceiver.Call();
        }
    }
}