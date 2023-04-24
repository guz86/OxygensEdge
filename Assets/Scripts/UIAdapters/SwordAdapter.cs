using GameElements;
using Gameplay.GameResources;
using UnityEngine;

namespace UIAdapters
{
    public class SwordAdapter : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    {
        [SerializeField] private GameObject _icon;

        private ResourceStorage _storage;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _storage = context.GetService<ResourceStorage>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _storage.OnResourceChanged += UpdatePanel;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _storage.OnResourceChanged -= UpdatePanel;
        }

        private void UpdatePanel(ResourceType type, int current)
        {
            if (type == ResourceType.SWORD && current != 0)
            {
                _icon.SetActive(true);
            }
        }

    }
}