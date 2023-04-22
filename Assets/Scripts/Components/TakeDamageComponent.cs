using Elementary;
using UnityEngine;

namespace Components
{
    public class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField] private EventBehaviour_Int _takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            
            Debug.Log("TakeDamageComponent  TakeDamage(int damage)" + damage);
            _takeDamageReceiver.Call(damage);
        }
    }
}