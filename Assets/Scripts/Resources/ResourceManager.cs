namespace Resources {
    public class ResourceManager {
         private ResourceVisual resourceVisual;
        private ResourceData resourceData;
        public ResourceManager(ResourceVisual resourceVisual, ResourceData resourceData) {
            this.resourceVisual = resourceVisual;
            this.resourceData = resourceData;
            resourceVisual.Init(resourceData);
        }
    }
}