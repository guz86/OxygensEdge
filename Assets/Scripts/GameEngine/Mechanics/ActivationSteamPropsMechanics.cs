using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class ActivationSteamPropsMechanics : MonoBehaviour
    {
        [SerializeField]
        private ActivationBehaviour toggle;

        [Space]
        [SerializeField]
        private GameObject[] gameObjects;

        private void OnEnable()
        {
            this.toggle.OnDeactivate += this.Activate;
        }

        private void OnDisable()
        {
            this.toggle.OnDeactivate -= this.Activate;
        }

        private void Activate()
        {
            this.SetActive(true);
        }

        private void Deactivate()
        {
            this.SetActive(false);
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