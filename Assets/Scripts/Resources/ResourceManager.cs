using UnityEngine;

namespace Resources {
    public class ResourceManager {
         private ResourceVisual resourceVisual;
        private ResourceData resourceData;
        public ResourceManager(ResourceVisual resourceVisual, ResourceData resourceData) {
            if (!resourceVisual) {
                Debug.LogError($"There is no resourceVisual assigned in ResourceManager. Aborting game startup");
                return;
            }
            
            this.resourceVisual = resourceVisual;
            this.resourceData = resourceData;
            resourceVisual.Init(resourceData);
        }
    }
}