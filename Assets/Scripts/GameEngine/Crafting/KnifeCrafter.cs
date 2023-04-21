using GameElements;
using Gameplay.GameResources;
using UnityEngine;

namespace GameEngine.Crafting
{
    public class KnifeCrafter : MonoBehaviour, IGameInitElement
    {
        private ResourceStorage _resourceStorage;

        public void InitGame(IGameContext context)
        {
            _resourceStorage = context.GetService<ResourceStorage>();
        }

        public bool CanCraft()
        {
            return (_resourceStorage.GetResource(ResourceType.STONE) >= 2 &&
                    _resourceStorage.GetResource(ResourceType.KNIFE) == 0);
        }

        public void Craft()
        {
            _resourceStorage.ExtractResource(ResourceType.STONE, 2);
            _resourceStorage.AddResource(ResourceType.KNIFE, 1);
        }
    }
}