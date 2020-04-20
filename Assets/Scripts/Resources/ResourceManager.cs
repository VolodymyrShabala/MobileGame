using System;
using UnityEngine;

namespace Resources {
    public class ResourceManager {
        private readonly ResourceData resourceData;
        public Action<int, string> onResourceUpdate;

        public ResourceManager(ResourceData resourceData) {
            this.resourceData = resourceData;

            Tick.instance.UpdateFunc(Update);
        }

        private void Update() {
            int length = GetNumberOfResources();

            for (int i = 0; i < length; i++) {
                if (!resourceData.resources[i].IsStorageFull() && resourceData.resources[i].IsUnlocked()) {
                    AddResource(i, resourceData.resources[i].GetGainPerSecond());
                    onResourceUpdate?.Invoke(i, resourceData.resources[i].ToString());
                }
            }
        }

        public void AddResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            Resource resource = resourceData.resources[resourceIndex];
            float currentAmount = resource.GetStorageAmount();
            float maxStorage = resource.GetStorageMax();

            if (currentAmount + amount <= maxStorage) {
                resource.AddResources(amount);
            } else {
                resource.AddResources(maxStorage - currentAmount);
            }

            resourceData.resources[resourceIndex] = resource;
        }

        public void RemoveResource(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            Resource resource = resourceData.resources[resourceIndex];
            float currentAmount = resource.GetStorageAmount();

            if (currentAmount >= amount) {
                resource.RemoveResources(amount);
            } else {
                resource.RemoveResources(amount - currentAmount);
            }

            resourceData.resources[resourceIndex] = resource;
        }

        public void IncreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.resources[resourceIndex].AddGainPerSecond(amount);
        }

        public void DecreaseProduction(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.resources[resourceIndex].RemoveGainPerSecond(amount);
        }

        public void IncreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.resources[resourceIndex].AddStorage(amount);
        }

        public void DecreaseStorage(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            Resource resource = resourceData.resources[resourceIndex];
            float maxStorage = resource.GetStorageMax();

            if (maxStorage >= amount) {
                resource.RemoveStorage(amount);
            } else {
                resource.RemoveStorage(amount - maxStorage);
            }

            resourceData.resources[resourceIndex] = resource;
        }

        public void UnlockResource(int resourceIndex) {
            if (!IsInRange(resourceIndex)) {
                return;
            }

            resourceData.resources[resourceIndex].SetUnlocked();
        }

        public bool IsUnlockedResource(int resourceIndex) {
            return IsInRange(resourceIndex) && resourceData.resources[resourceIndex].IsUnlocked();
        }

        public bool IsEnoughResources(int resourceIndex, float amount) {
            if (!IsInRange(resourceIndex)) {
                return false;
            }

            return resourceData.resources[resourceIndex].GetStorageAmount() >= amount;
        }

        public string GetResourceName(int resourceIndex) {
            return resourceData.resources[resourceIndex].GetName();
        }

        public int GetNumberOfResources() {
            return resourceData.resources.Length;
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