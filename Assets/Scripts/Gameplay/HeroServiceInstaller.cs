using Modules.Entities;
using UnityEngine;

namespace Gameplay
{
    public class HeroServiceInstaller : MonoBehaviour
    {
        [SerializeField]
        private UnityEntityBase hero;

        [SerializeField]
        private HeroService heroService;
    
        private void Awake()
        {
            this.heroService.SetupHero(this.hero);
        }
    }
}