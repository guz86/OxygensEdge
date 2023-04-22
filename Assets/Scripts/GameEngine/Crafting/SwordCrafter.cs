using GameElements;
using Gameplay.GameResources;
using UnityEngine;

namespace GameEngine.Crafting
{
    public class SwordCrafter : MonoBehaviour, IGameInitElement
    {
        private ResourceStorage _resourceStorage;

        public void InitGame(IGameContext context)
        {
            _resourceStorage = context.GetService<ResourceStorage>();
        }

        public bool CanCraft()
        {
            return (_resourceStorage.GetResource(ResourceType.BONE) >= 2 &&
                    _resourceStorage.GetResource(ResourceType.SWORD) == 0);
        }

        public void Craft()
        {
            _resourceStorage.ExtractResource(ResourceType.BONE, 2);
            _resourceStorage.AddResource(ResourceType.SWORD, 1);
        }
    }
}