using UnityEngine;

namespace Resources {
    public class ResourceManager {
        private readonly Resource[] resources;

        public ResourceManager(Resource[] resources) {
            this.resources = resources;

            Tick.instance.UpdateFunc(Update);
        }
        
        private void Update() {
            int length = GetResourceAmount();

            for (int i = 0; i < length; i++) {
                resources[i].Update();
            }
        }

        public void AddResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].AddResources(amount);
        }

        public void RemoveResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].RemoveResources(amount);
        }

        public void IncreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].AddGainPerSecond(amount);
        }

        public void DecreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].RemoveGainPerSecond(amount);
        }
        
        public void IncreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].AddStorage(amount);
        }

        public void DecreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].RemoveStorage(amount);
        }

        public void UnlockResource(int resourceIndex) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].SetUnlocked();
        }

        public bool IsUnlockedResource(int resourceIndex) {
            return IsInRange(resourceIndex) && resources[resourceIndex].IsUnlocked();
        }

        public bool IsEnoughResources(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return false;
            }

            return resources[resourceIndex].GetStorageAmount() >= amount;
        }

        public Resource GetResource(int resourceIndex) {
            return !IsInRange(resourceIndex) ? null : resources[resourceIndex];
        }

        public int GetResourceAmount() {
            return resources.Length;
        }

        // TODO: Remove Debug.Log when done
        private bool IsInRange(int resourceIndex) {
            if (resourceIndex >= 0 && resourceIndex < GetResourceAmount()) {
                return true;
            }

            Debug.Log($"Trying to access index out of range. Index: {resourceIndex}, Max index allowed: {GetResourceAmount() - 1}. {StackTraceUtility.ExtractStackTrace()}");

            return false;
        }
    }
}