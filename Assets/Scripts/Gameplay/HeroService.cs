using Modules.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay
{
    public class HeroService : MonoBehaviour
    {
        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        private IEntity currentHero;

        public void SetupHero(IEntity hero)
        {
            this.currentHero = hero;
        }

        public IEntity GetHero()
        {
            return this.currentHero;
        }
    }
}