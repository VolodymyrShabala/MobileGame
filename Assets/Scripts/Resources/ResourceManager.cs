using System;
using UnityEngine;

namespace Resources {
    public class ResourceManager {
        private readonly Resource[] resources;
        public Action<int, string> onResourceUpdate;

        public ResourceManager(Resource[] resources) {
            this.resources = resources;

            Tick.instance.UpdateFunc(Update);
        }

        private void Update() {
            int length = GetNumberOfResources();

            for (int i = 0; i < length; i++) {
                if (!resources[i].IsStorageFull() && resources[i].IsUnlocked()) {
                    AddResource(i, resources[i].GetGainPerSecond());
                    onResourceUpdate?.Invoke(i, resources[i].ToString());
                }
            }
        }

        public void AddResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            Resource resource = resources[resourceIndex];
            float currentAmount = resource.GetCurrentAmount();
            float maxStorage = resource.GetStorageMax();

            if (currentAmount + amount <= maxStorage) {
                resource.AddResources(amount);
            } else {
                resource.AddResources(maxStorage - currentAmount);
            }

            resources[resourceIndex] = resource;
        }

        public void RemoveResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            Resource resource = resources[resourceIndex];
            float currentAmount = resource.GetCurrentAmount();

            if (currentAmount >= amount) {
                resource.RemoveResources(amount);
            } else {
                resource.RemoveResources(amount - currentAmount);
            }

            resources[resourceIndex] = resource;
        }

        public void IncreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].IncreaseGainPerSecond(amount);
        }

        public void DecreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].DecreaseGainPerSecond(amount);
        }

        public void IncreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resources[resourceIndex].IncreaseStorage(amount);
        }

        public void DecreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            Resource resource = resources[resourceIndex];
            float maxStorage = resource.GetStorageMax();

            if (maxStorage >= amount) {
                resource.DecreaseStorage(amount);
            } else {
                resource.DecreaseStorage(amount - maxStorage);
            }

            resources[resourceIndex] = resource;
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

            return resources[resourceIndex].GetCurrentAmount() >= amount;
        }

        public string GetResourceName(int resourceIndex) {
            return resources[resourceIndex].GetName();
        }

        public int GetNumberOfResources() {
            return resources.Length;
        }

        // TODO: Remove Debug.Log
        private bool IsInRange(int resourceIndex) {
            if (resourceIndex >= 0 && resourceIndex < GetNumberOfResources()) {
                return true;
            }

            Debug.Log($"Trying to access index out of range. Index: {resourceIndex}, Max index allowed: {GetNumberOfResources() - 1}. {StackTraceUtility.ExtractStackTrace()}");

            return false;
        }
    }
}