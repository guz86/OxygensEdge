using System;
using System.Collections;
using Components.Collect;
using Components.Resources_Components;
using GameElements;
using Gameplay.GameResources;
using Modules.Entities;
using UnityEngine;

namespace Gameplay.Interact
{
    public class HarvestResourceInteractor : MonoBehaviour, IGameInitElement
    {
        
        public event Action<IEntity> OnHarvestCompleted;

        public bool IsHarvesting { get; private set; }

        private ResourceStorage resourceStorage;

        [SerializeField]
        private ScriptableEntityCondition isResourceActive;

        [SerializeField] private float duration = 5;

        private IEntity currentResource;

        private Coroutine harvestCoroutine;
        

        public bool CanHarvest(IEntity resource)
        {
            if (!this.isResourceActive.IsTrue(resource))
            {
                return false;
            }

            return true;
        }

        public void StartHarvest(IEntity resource)
        {
            if (!this.CanHarvest(resource))
            {
                Debug.LogWarning("Can't harvest");
                return;
            }

            Debug.Log("START HARVEST");
            this.IsHarvesting = true;
            this.currentResource = resource;
             this.harvestCoroutine = this.StartCoroutine(this.StartHarvestRoutine());
        }

        public void CancelHarvest()
        {
            if (this.IsHarvesting)
            {
                Debug.Log("CANCEL HARVEST");
                this.StopCoroutine(this.harvestCoroutine);
                this.ResetState();
            }
        }

        private IEnumerator StartHarvestRoutine()
        {
            yield return new WaitForSeconds(this.duration);

            var resource = this.currentResource;
            this.DestroyResource(resource);
            this.AddResourcesToStorage(resource);
            this.ResetState();

            Debug.Log("FINISH HARVEST");
            this.OnHarvestCompleted?.Invoke(resource);
        }

        private void DestroyResource(IEntity resource)
        {
            if (resource != null)
            {
                resource.Get<IComponent_Collect>().Collect();
            }
            
        }

        private void AddResourcesToStorage(IEntity resource)
        {
            var resourceType = resource.Get<IComponent_GetResourceType>().Type;
            var resourceAmount = resource.Get<IComponent_GetResourceCount>().Count;
            this.resourceStorage.AddResource(resourceType, resourceAmount);
        }

        private void ResetState()
        {
            this.currentResource = null;
            this.IsHarvesting = false;
            this.harvestCoroutine = null;
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.resourceStorage = context.GetService<ResourceStorage>();
        }
    }
}