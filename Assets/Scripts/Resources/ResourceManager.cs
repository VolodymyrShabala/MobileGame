using UnityEngine;

namespace Resources {
    public class ResourceManager : MonoBehaviour {
        [SerializeField] private ResourceVisual resourceVisual;
        private ResourceData resourceData;
        private Resource[] resources;
        private void Start() {
            resourceData = FileReader.LoadResourceData();
            if (resourceData.GetNumberOfUnlockedResources() == 0) {
                FirstTimeLoad();
            }

            resourceData.GetResource(ResourceType.Wood);
            resourceVisual.Init(resourceData);
        }

        // TODO: Move somewhere else
        private void FirstTimeLoad() {
            resources = new Resource[1];
            resources[0] = new Resource(ResourceType.Food, 0, 10, 0);
            resourceData = new ResourceData(resources);
            FileReader.SaveResourceData(resourceData);
        }
    }
}