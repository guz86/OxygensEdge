using Components;
using GameElements;
using GameEngine.Mechanics.Collisions;
using Gameplay;
using Modules.Entities;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class TouchCheckController : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    {
        [SerializeField] private string _colliderTag = "Enemy";

        private IEntity _character;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _character = context.GetService<HeroService>().GetHero();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _character.Get<IComponent_TriggerEvents>().OnEntered += OnHeroEntered;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _character.Get<IComponent_TriggerEvents>().OnEntered -= OnHeroEntered;
        }


        private void OnHeroEntered(Collider other)
        {
            if (other.CompareTag(_colliderTag))
            {
                _character.Get<ITouchComponent>().OnTouch();
            }
        }
    }
}