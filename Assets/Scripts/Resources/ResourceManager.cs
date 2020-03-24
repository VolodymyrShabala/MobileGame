using UnityEngine;

namespace Resources {
    public class ResourceManager : MonoBehaviour {
        [SerializeField] private ResourceVisual resourceVisual;
        private Resource[] resources;
        private void Start() {
            resources = FileReader.LoadResources();

            if (resources == null) { // First time loading game
                FirstTimeLoad();
            }

            resourceVisual.Init(resources);
        }

        private void FirstTimeLoad() {
            resources = new Resource[1];
            resources[0] = new Resource("Food", 0, 10, 0);
            FileReader.SaveResources(resources);
        }
    }
}