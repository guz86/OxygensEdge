using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/State")]
    public class State : MonoBehaviour
    {
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}