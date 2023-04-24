using GameElements;
using GameEngine.Mechanics;
using GameEngine.Mechanics.Collisions;
using Gameplay;
using UnityEngine;
using IEntity = Modules.Entities.IEntity;

namespace GameEngine.Controllers
{
    public class FogCheckController : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    {
        [SerializeField] private string _colliderTag = "Fog";
        
        private IEntity _character;
        
        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _character = context.GetService<HeroService>().GetHero();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _character.Get<IComponent_TriggerEvents>().OnEntered += OnHeroEntered;
            _character.Get<IComponent_TriggerEvents>().OnExited += OnHeroExited;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _character.Get<IComponent_TriggerEvents>().OnEntered -= OnHeroEntered;
            _character.Get<IComponent_TriggerEvents>().OnExited -= OnHeroExited;
        }


        private void OnHeroEntered(Collider other)
        {
            //Debug.Log("FogCheckController Staying"+ other.tag);
            if (other.CompareTag(_colliderTag))
            {
                //_character.Get<ISendDeathComponent>().Die(); 
                _character.Get<IFogOxygenPointsComponent>().InFog();
            }
        }
        
        
        private void OnHeroExited(Collider obj)
        {
           // Debug.Log("FogCheckController OnHeroExited"+ obj.tag);
            if (obj.CompareTag(_colliderTag))
            {
                _character.Get<IFogOxygenPointsComponent>().OutFog();
            }
        }
    }
}