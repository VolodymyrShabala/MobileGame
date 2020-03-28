using Resources;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private ResourceVisual resourceVisual;
    private void Start() {
        if (!resourceVisual) {
            resourceVisual = FindObjectOfType<ResourceVisual>();

            if (!resourceVisual) {
                Debug.LogError($"There is no ResourceVisual assigned in {name}. Aborting game startup.");
            }
        }

        ResourceData resourceData = ResourceDataLoader.LoadOrCreateResourceData();
        ResourceManager resourceManager = new ResourceManager(resourceVisual, resourceData);
    }
}