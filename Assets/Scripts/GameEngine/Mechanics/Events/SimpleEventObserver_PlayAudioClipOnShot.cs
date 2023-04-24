using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics.Events
{
    public class SimpleEventObserver_PlayAudioClipOnShot : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private EventBehaviour _receiver;

        private void OnEnable()
        {
            _receiver.OnEvent += OnEvent;
        }

        private void OnDisable()
        {
            _receiver.OnEvent += OnEvent;
        }

        private void OnEvent()
        {
            _source.PlayOneShot(_clip);
        }
    }
}