using GameElements;
using Gameplay.GameResources;
using UnityEngine;

namespace GameEngine.Crafting
{
    public class OxygenCrafter : MonoBehaviour, IGameInitElement
    {
        private ResourceStorage _resourceStorage;

        public void InitGame(IGameContext context)
        {
            _resourceStorage = context.GetService<ResourceStorage>();
        }

        public bool CanCraft()
        {
            return (_resourceStorage.GetResource(ResourceType.FRUIT) >= 1 &&
                    _resourceStorage.GetResource(ResourceType.ROOTS) >= 1 &&
                    _resourceStorage.GetResource(ResourceType.PLANTS) >= 1);
        }

        public void Craft()
        {
            _resourceStorage.ExtractResource(ResourceType.FRUIT, 1);
            _resourceStorage.ExtractResource(ResourceType.ROOTS, 1);
            _resourceStorage.ExtractResource(ResourceType.PLANTS, 1);
            _resourceStorage.AddResource(ResourceType.OXYGEN, 1);
        }
    }
}