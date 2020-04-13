using UnityEngine;

namespace Resources {
    public class ResourceManager {
        private readonly ResourceVisual resourceVisual;
        private ResourceData resourceData;

        public ResourceManager(ResourceVisual resourceVisual, ResourceData resourceData) {
            if (!resourceVisual) {
                Debug.LogError($"There is no resourceVisual assigned in ResourceManager. Aborting game startup");
                return;
            }

            this.resourceVisual = resourceVisual;
            this.resourceData = resourceData;
            
            // TODO: Doesn't look good
            Tick.instance.UpdateFunc(delegate {
                resourceData.Update();
                resourceVisual.UpdateResources();
                 });
        }

        public void AddResource(int resourceIndex, float amount) {
            resourceData.Add(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void RemoveResource(int resourceIndex, float amount) {
            resourceData.Remove(resourceIndex, amount);
        }

        public void IncreaseProduction(int resourceIndex, float amount) {
            resourceData.IncreaseProduction(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void DecreaseProduction(int resourceIndex, float amount) {
            resourceData.DecreaseProduction(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void UnlockResource(int resourceIndex) {
            resourceData.Unlock(resourceIndex);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public bool IsUnlockedResource(int resourceIndex) {
            return resourceData.IsUnlocked(resourceIndex);
        }

        public bool InEnoughResources(int resourceIndex, float amount) {
            return resourceData.IsEnoughResource(resourceIndex, amount);
        }

        public void IncreaseStorage(int resourceIndex, float amount) {
            resourceData.IncreaseStorage(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void DecreaseStorage(int resourceIndex, float amount) {
            resourceData.DecreaseStorage(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }
    }
}