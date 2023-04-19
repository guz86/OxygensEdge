using Components;
using GameElements;
using Gameplay;
using Modules.Entities;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class CharacterDeathController : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    { 
        private IGameContext _gameContext;
        private IEntity _character;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _gameContext = context;
            _character = context.GetService<HeroService>().GetHero();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _character.Get<IEventDeathComponent>().OnDied += OnHeroDied;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _character.Get<IEventDeathComponent>().OnDied -= OnHeroDied;
        }

        private void OnHeroDied()
        {
            _gameContext.FinishGame();
        }
    }
}