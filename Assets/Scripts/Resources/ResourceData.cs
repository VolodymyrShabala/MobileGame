namespace Resources {
    [System.Serializable]
    public struct ResourceData {
        private Resource[] unlockedResources; // TODO: Needs to be readonly. List?

        public ResourceData(Resource[] unlockedResources) {
            this.unlockedResources = unlockedResources;
        }

        public void Add(ResourceType resourceType, float amount) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    unlockedResources[i].amount += amount;
                }
            }
        }

        public void Remove(ResourceType resourceType, float amount) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    unlockedResources[i].amount -= amount;
                }
            }
        }

        public void IncreaseProduction(ResourceType resourceType, float increase) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    unlockedResources[i].gainPerSecond += increase;
                }
            }
        }

        public void DecreaseProduction(ResourceType resourceType, float decrease) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    unlockedResources[i].gainPerSecond -= decrease;
                }
            }
        }

        public void Unlock(ResourceType resourceType) {
            int length = unlockedResources.Length;
            Resource[] temp = new Resource[length + 1];

            for (int i = 0; i < length; i++) {
                temp[i] = unlockedResources[i];
            }
            temp[length + 1] = new Resource(resourceType, 0, 10, 0);
            unlockedResources = temp;
        }

        public int GetNumberOfUnlockedResources() {
            return unlockedResources.Length;
        }
        
        public Resource GetResource(ResourceType resourceType) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    return unlockedResources[i];
                }
            }

            return default;
        }
        
        public bool IsUnlocked(ResourceType resourceType) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    return true;
                }
            }

            return false;
        }
    }
}