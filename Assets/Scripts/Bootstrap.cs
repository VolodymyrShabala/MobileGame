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

        ResourceData resourceData = ResourceDataLoader.LoadOrCreateResourceData();
        ResourceManager resourceManager = new ResourceManager(resourceVisual, resourceData);
        
        Building[] buildings = new Building[1];
        buildings[0].buildingType = BuildingType.Farm;
        buildings[0].buildAmount = 0;
        buildings[0].description = "Huh";
        buildings[0].active = true;
        BuildingData buildingData = new BuildingData(buildings);
        
        BuildingManager buildingManager = new BuildingManager(buildingVisual, buildingData);
    }
}