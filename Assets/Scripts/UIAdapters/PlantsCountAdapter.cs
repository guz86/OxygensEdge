using GameElements;
using Gameplay.GameResources;
using UI;
using UnityEngine;

namespace UIAdapters
{
    public class PlantsCountAdapter : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    { 
        [SerializeField] private GameObject _Icon;
        
        [SerializeField] private TextPanel _panel;

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
            if (type == ResourceType.PLANTS && current != 0)
            {
                _panel.UpdateValue(current.ToString());
                _Icon.SetActive(true);
            }

            CheckResource();
        }

        private void CheckResource()
        {
            var count = _storage.GetResource(ResourceType.PLANTS);
            if (count == 0)
            {
                _panel.UpdateValue("");
                _Icon.SetActive(false);
            }
        }
    }
} 