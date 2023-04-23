using Elementary;
using UnityEngine;

namespace Components
{
    public class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField] private EventBehaviour_Int _takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            _takeDamageReceiver.Call(damage);
        }
    }
}