using UnityEngine;

namespace Resources {
    public class ResourceManager {
        private readonly ResourceVisual resourceVisual;
        private readonly ResourceData resourceData;

        public ResourceManager(ResourceVisual resourceVisual, ResourceData resourceData) {
            if (!resourceVisual) {
                Debug.LogError($"There is no resourceVisual assigned in ResourceManager. Aborting game startup");
                return;
            }

            this.resourceVisual = resourceVisual;
            this.resourceData = resourceData;
        }

        public void Update(float deltaTime) {
            resourceData.Update(deltaTime);
        }

        public void AddResource(ResourceType resourceType, float amount) {
            int resourceIndex = (int) resourceType;
            resourceData.Add(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void RemoveResource(ResourceType resourceType, float amount) {
            resourceData.Remove((int) resourceType, amount);
        }

        public void IncreaseProduction(ResourceType resourceType, float amount) {
            int resourceIndex = (int) resourceType;
            resourceData.IncreaseProduction(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void DecreaseProduction(ResourceType resourceType, float amount) {
            int resourceIndex = (int) resourceType;
            resourceData.DecreaseProduction(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void UnlockResource(ResourceType resourceType) {
            int resourceIndex = (int) resourceType;
            resourceData.UnlockResource(resourceIndex);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public bool IsUnlockedResource(ResourceType resourceType) {
            return resourceData.IsUnlockedResource((int) resourceType);
        }

        public bool InEnoughResources(ResourceType resourceType, float amount) {
            return resourceData.IsEnoughResource((int) resourceType, amount);
        }

        public void IncreaseStorage(ResourceType resourceType, float amount) {
            int resourceIndex = (int) resourceType;
            resourceData.IncreaseStorage(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void DecreaseStorage(ResourceType resourceType, float amount) {
            int resourceIndex = (int) resourceType;
            resourceData.DecreaseStorage(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }
    }
}