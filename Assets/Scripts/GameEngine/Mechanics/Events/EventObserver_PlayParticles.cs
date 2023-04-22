using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public class EventObserver_PlayParticles : AbstractEventObserver
    { 
        [SerializeField] private ParticleSystem[] _particles;
 
        protected override void OnEvent(int value)
        {
            foreach (var particle in this._particles)
            {
                particle.Play(withChildren: true);
            }
        }
    }
}