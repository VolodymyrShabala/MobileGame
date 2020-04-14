using UnityEngine;

namespace Resources {
    // TODO: Right now ResourceManager works only on ResourceData. Maybe move ResourceData to ResourceManager? I can have just ResourceManager and ResourceVisual
    public class ResourceManager {
        private readonly ResourceVisual resourceVisual;
        private ResourceData resourceData;

        public ResourceManager(ResourceVisual resourceVisual, ResourceData resourceData) {
            UnityEngine.Assertions.Assert.IsNotNull(resourceVisual,
                                                    $"ResourceVisual isn't assigned in ResourceManager.");

            this.resourceVisual = resourceVisual;
            this.resourceData = resourceData;

            // TODO: Doesn't look good
            // TODO: Need to be able to remove when is disabled
            Tick.instance.UpdateFunc(delegate {
                resourceData.Update();
                resourceVisual.UpdateResources();
            });
        }

        public void AddResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.Add(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void RemoveResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.Remove(resourceIndex, amount);
        }

        public void IncreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.IncreaseProduction(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void DecreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.DecreaseProduction(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void UnlockResource(int resourceIndex) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.Unlock(resourceIndex);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public bool IsUnlockedResource(int resourceIndex) {
            if (!IsInRange(resourceIndex)) {
                return false;
            }

            return resourceData.IsUnlocked(resourceIndex);
        }

        public bool IsEnoughResources(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return false;
            }

            return resourceData.IsEnoughResource(resourceIndex, amount);
        }

        public void IncreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.IncreaseStorage(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public void DecreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.DecreaseStorage(resourceIndex, amount);
            resourceVisual.UpdateResource(resourceIndex);
        }

        public Resource GetResource(int resourceIndex) {
            if (!IsInRange(resourceIndex)) {
                return default;
            }

            return resourceData.GetResource(resourceIndex);
        }

        // Do not like it here
        public int GetResourceAmount() {
            return resourceData.Length;
        }

        private bool IsInRange(int resourceIndex) {
            if (resourceIndex >= 0 && resourceIndex < resourceData.Length) {
                return true;
            }

            Debug.Log($"Trying to access index out of range. Index: {resourceIndex}, Max index allowed: {resourceData.Length - 1}. {StackTraceUtility.ExtractStackTrace()}");

            return false;
        }
    }
}