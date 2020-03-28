namespace Resources {
    public static class ResourceDataLoader {
        public static ResourceData LoadOrCreateResourceData() {
            ResourceData resourceData = FileReader.LoadResourceData();
        
            return resourceData.GetNumberOfUnlockedResources() == 0 ? CreateResourceData() : resourceData;
        }

        private static ResourceData CreateResourceData() {
            Resource[] resources = new Resource[1];
            resources[0] = new Resource(ResourceType.Food, 0, 10, 0);
            ResourceData resourceData = new ResourceData(resources);
            return resourceData;
        }
    }
}