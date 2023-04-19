using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class FogOxygenPointsComponent : MonoBehaviour, IFogOxygenPointsComponent
    {
        [SerializeField] private EventBehaviour _inFogReceiver;
        [SerializeField] private EventBehaviour _outFogReceiver;
        
        public void InFog()
        {
            _inFogReceiver.Call();
        }
        
        public void OutFog()
        {
            _outFogReceiver.Call();
        }
    }
}