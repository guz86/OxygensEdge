using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public class EventObserver_PlayAudioClipOnShot : AbstractEventObserver
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;
 
        protected override void OnEvent(int damage)
        {
            _source.PlayOneShot(_clip);
        }
    }
}