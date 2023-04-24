using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public sealed class DeathMechanics_AddBoneDisableGameobject : MonoBehaviour
    {
        //[SerializeField] private GameObject _target;
        [Space]
        [SerializeField]
        private GameObject[] gameObjects;
        [SerializeField] private GameObject _bones;
        [SerializeField] private EventBehaviour _deathReceiver;


        private void OnEnable()
        {
            _deathReceiver.OnEvent += OnDeath;
        }

        private void OnDisable()
        {
            _deathReceiver.OnEvent -= OnDeath;
        }


        private void OnDeath()
        {
            _bones.SetActive(true);
            SetActive(false);
        }
        
        private void SetActive(bool isActive)
        {
            for (int i = 0, count = this.gameObjects.Length; i < count; i++)
            {
                var gameObject = this.gameObjects[i];
                gameObject.SetActive(isActive);
            }
        }
    }
}