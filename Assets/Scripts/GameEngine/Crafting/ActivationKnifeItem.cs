/*using GameElements;
using Gameplay;
using UnityEngine;
using IEntity = Modules.Entities.IEntity;

namespace GameEngine.Crafting
{
    public class ActivationKnifeItem : MonoBehaviour, 
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private CrafterController _craftController;
        private IEntity _hero;
         
        public void InitGame(IGameContext context)
        {
            _craftController = context.GetService<CrafterController>();
            _hero = context.GetService<HeroService>().GetHero();
        }

        public void StartGame(IGameContext context)
        {
            _craftController.OnKnifeCrafted += ActivateKnife;
        }

        public void FinishGame(IGameContext context)
        {
            _craftController.OnKnifeCrafted -= ActivateKnife;
        }
        
        private void ActivateKnife()
        {
            var activationKnife = _hero.Get<IComponent_ActivationKnife>();
            activationKnife.Activate();
           
        }
    }
}*/