using System;
using GameElements;
using Gameplay.GameResources;
using UnityEngine;

namespace GameEngine.Crafting
{
    public class CrafterController : MonoBehaviour, 
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        public event Action OnKnifeCrafted;
        public event Action OnSwordCrafted;
        public event Action OnOxygenCrafted;

        private ResourceStorage _resourceStorage;
        private KnifeCrafter _knifeCrafted;
        private SwordCrafter _swordCrafted;
        private OxygenCrafter _oxygenCrafted;

        public void InitGame(IGameContext context)
        {
            _resourceStorage = context.GetService<ResourceStorage>();
            _knifeCrafted = context.GetService<KnifeCrafter>();
            _swordCrafted = context.GetService<SwordCrafter>();
            _oxygenCrafted = context.GetService<OxygenCrafter>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _resourceStorage.OnResourceChanged += CheckCrafted;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _resourceStorage.OnResourceChanged -= CheckCrafted;
        }

        private void CheckCrafted(ResourceType type, int count)
        {
            if (type == ResourceType.STONE)
            {
                if (_knifeCrafted.CanCraft())
                {
                    _knifeCrafted.Craft();
                    OnKnifeCrafted?.Invoke();
                }
            }
            
            if (type == ResourceType.BONE)
            {
                if (_swordCrafted.CanCraft())
                {
                    _swordCrafted.Craft();
                    OnSwordCrafted?.Invoke();
                }
            }

            if (type is ResourceType.FRUIT 
                or ResourceType.ROOTS 
                or ResourceType.PLANTS)
            {
                
                if (_oxygenCrafted.CanCraft())
                {
                    _oxygenCrafted.Craft();
                    OnOxygenCrafted?.Invoke();
                }
            }
            
        }
    }
}