using GameElements;
using Gameplay;
using UnityEngine;
using IEntity = Modules.Entities.IEntity;

namespace GameEngine.Crafting
{
    public class ActivationItem : MonoBehaviour, 
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private CrafterController _craftController;
        private IEntity _hero;
        private IComponent_ActivationKnife _activationKnife;
        private IComponent_ActivationSword _activationSword;

        public void InitGame(IGameContext context)
        {
            _craftController = context.GetService<CrafterController>();
            _hero = context.GetService<HeroService>().GetHero();
            
            _activationKnife = _hero.Get<IComponent_ActivationKnife>();
            _activationSword = _hero.Get<IComponent_ActivationSword>();
        }

        public void StartGame(IGameContext context)
        {
            _craftController.OnKnifeCrafted += ActivateKnife;
            _craftController.OnSwordCrafted += ActivateSword;
        }


        public void FinishGame(IGameContext context)
        {
            _craftController.OnKnifeCrafted -= ActivateKnife;
        }
        
        private void ActivateKnife()
        {
            _activationKnife.Activate();
        }
        
        private void ActivateSword()
        {
            _activationKnife.DeActivate();
            _activationSword.Activate();
        }
    }
}