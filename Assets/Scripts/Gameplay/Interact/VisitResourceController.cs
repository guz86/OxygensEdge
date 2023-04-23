using GameElements;
using GameEngine.Mechanics;
using GameEngine.Mechanics.Collisions;
using Modules.Entities;
using UnityEngine;
using IEntity = Modules.Entities.IEntity;

namespace Gameplay.Interact
{
    public sealed class VisitResourceController : MonoBehaviour, 
        //IGameConstructElement,
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private HarvestResourceInteractor harvestInteractor;
        
        private IComponent_CollisionEvents heroComponent;
        
        //private HeroService heroService;

        [SerializeField] private ScriptableEntityCondition isResourceCondition;

        // void IGameConstructElement.ConstructGame(IGameContext context)
        // {
        //     // this.heroService = context.GetService<HeroService>();
        //     // this.harvestInteractor = context.GetService<HarvestResourceInteractor>();
        //     //this.hero = context.GetService<HeroService>().GetHero();
        //     this.harvestInteractor = context.GetService<HarvestResourceInteractor>();
        // }
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            var hero = context.GetService<HeroService>().GetHero();
            this.heroComponent = hero.Get<IComponent_CollisionEvents>();
            this.harvestInteractor = context.GetService<HarvestResourceInteractor>();
        }

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            this.heroComponent.OnCollisionEntered += this.OnHeroEntered;
            this.heroComponent.OnCollisionExited += this.OnHeroExited;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            this.heroComponent.OnCollisionEntered -= this.OnHeroEntered;
            this.heroComponent.OnCollisionExited -= this.OnHeroExited;
        }


        private void OnHeroEntered(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity) && this.isResourceCondition.IsTrue(entity))
            {
                if (this.harvestInteractor.CanHarvest(entity))
                {
                    this.harvestInteractor.StartHarvest(entity);
                }
            }
        }

        private void OnHeroExited(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity) && this.isResourceCondition.IsTrue(entity))
            {
                if (this.harvestInteractor.IsHarvesting)
                {
                    this.harvestInteractor.CancelHarvest();
                }
            }
        }
    }
}