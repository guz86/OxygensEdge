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
        public event Action OnOxygenCrafted;

        private ResourceStorage _resourceStorage;
        private KnifeCrafter _knifeCrafted;
        private OxygenCrafter _oxygenCrafted;

        public void InitGame(IGameContext context)
        {
            _resourceStorage = context.GetService<ResourceStorage>();
            _knifeCrafted = context.GetService<KnifeCrafter>();
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

            if (type is ResourceType.FRUIT 
                or ResourceType.ROOTS 
                or ResourceType.PLANTS)
            {
                Debug.Log("_oxygenCrafted.CanCraft()"+ _oxygenCrafted.CanCraft());
                if (_oxygenCrafted.CanCraft())
                {
                    _oxygenCrafted.Craft();
                    OnOxygenCrafted?.Invoke();
                }
            }
        }
    }
}