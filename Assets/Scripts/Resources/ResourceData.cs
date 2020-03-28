using UnityEngine;

namespace Resources {
    [System.Serializable]
    public struct ResourceData { // TODO: Look into creating a function returning a ref to a resource to skip all those loops
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
            int length = GetNumberOfUnlockedResources();
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

        public bool IsUnlocked(ResourceType resourceType) {
            return GetResource(resourceType).resourceType == resourceType;
        }

        public bool IsEnoughResource(ResourceType resourceType, int amount) {
            Resource resource = GetResource(resourceType);

            if (resource.resourceType == resourceType) {
                return resource.amount >= amount;
            }
            
            return false;
        }
        
        public Resource GetResource(ResourceType resourceType) {
            for (int i = 0; i < unlockedResources.Length; i++) {
                if (unlockedResources[i].resourceType == resourceType) {
                    return unlockedResources[i];
                }
            }

            Debug.Log($"Trying to access locked resource {resourceType}.");
            return default; // TODO: Look into what can be done here. Problem with default is that I need to have a check
                            // in every call from this function. 
        }
    }
}