using Buildings;
using Resources;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private ResourceVisual resourceVisual;
    [SerializeField] private BuildingVisual buildingVisual;
    private void Start() {
        if (!resourceVisual) {
            resourceVisual = FindObjectOfType<ResourceVisual>();

            if (!resourceVisual) {
                Debug.LogError($"There is no ResourceVisual assigned in {name}. Aborting game startup.");
            }
        }
        
        if (!buildingVisual) {
            buildingVisual = FindObjectOfType<BuildingVisual>();

            if (!buildingVisual) {
                Debug.LogError($"There is no BuildingVisual assigned in {name}. Aborting game startup.");
            }
        }

        ResourceData resourceData = (ResourceData) DataLoader.LoadOrCreateData(FileType.Resources);
        ResourceManager resourceManager = new ResourceManager(resourceVisual, resourceData);
        
        BuildingData buildingData = (BuildingData) DataLoader.LoadOrCreateData(FileType.Buildings);
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(resourceManager);
        BuildingManager buildingManager = new BuildingManager(buildingVisual, buildingEffectManager, buildingData);
    }
}