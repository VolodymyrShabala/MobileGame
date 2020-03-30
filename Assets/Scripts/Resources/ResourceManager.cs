namespace Resources {
    public class ResourceManager {
        private ResourceVisual resourceVisual;
        private readonly ResourceData resourceData;

        public ResourceManager(ResourceVisual resourceVisual, ResourceData resourceData) {
            if (!resourceVisual) {
                UnityEngine
                        .Debug
                        .LogError($"There is no resourceVisual assigned in ResourceManager. Aborting game startup");

                return;
            }

            this.resourceVisual = resourceVisual;
            this.resourceData = resourceData;
            resourceVisual.Init(resourceData);
        }

        public void AddResource(ResourceType resourceType, float amount) {
            resourceData.Add(GetResourceIndex(resourceType), amount);
        }

        public void RemoveResource(ResourceType resourceType, float amount) {
            resourceData.Remove(GetResourceIndex(resourceType), amount);
        }

        public void IncreaseProductionResource(ResourceType resourceType, float amount) {
            resourceData.IncreaseProduction(GetResourceIndex(resourceType), amount);
        }

        public void DecreaseProductionResource(ResourceType resourceType, float amount) {
            resourceData.DecreaseProduction(GetResourceIndex(resourceType), amount);
        }

        public void UnlockResource(ResourceType resourceType) {
            resourceData.UnlockResource(GetResourceIndex(resourceType));
        }

        public bool IsUnlockedResource(ResourceType resourceType) {
            return resourceData.IsUnlockedResource(GetResourceIndex(resourceType));
        }

        public bool InEnoughResources(ResourceType resourceType, float amount) {
            return resourceData.IsEnoughResource(GetResourceIndex(resourceType), amount);
        }

        private int GetResourceIndex(ResourceType resourceType) {
            int length = resourceData.GetNumberOfResources();

            for (int i = 0; i < length; i++) {
                if (resourceData.GetResource(i).resourceType == resourceType) {
                    return i;
                }
            }

            UnityEngine.Debug.LogError($"Trying to access non existent resource {resourceType}.");
            return -1;
        }
    }
}