using Components;
using GameElements;
using Gameplay;
using Gameplay.GameResources;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class OxygenController : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    { 
        private OxygenInput _input;

        private IOxygenPointsComponent _oxygenComponent;
        private ResourceStorage _storage;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _input = context
                .GetService<OxygenInput>();
            _oxygenComponent = context
                .GetService<HeroService>()
                .GetHero()
                .Get<IOxygenPointsComponent>();
            _storage = context
                .GetService<ResourceStorage>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _input.OnOxygen += OnOxygened;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _input.OnOxygen -= OnOxygened;
        }
        
        private void OnOxygened()
        {
            if (_storage.GetResource(ResourceType.OXYGEN) > 0)
            {
                _storage.ExtractResource(ResourceType.OXYGEN, 1);
                
                _oxygenComponent.FullOxygenPoints(); 
            }
        }

    }
}