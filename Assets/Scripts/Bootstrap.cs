using Buildings;
using Resources;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private ResourceVisual resourceVisual;
    [SerializeField] private BuildingVisual buildingVisual;
    private void Start() {
        ResourceData resourceData = (ResourceData) DataLoader.LoadOrCreateData(FileType.Resources);
        ResourceManager resourceManager = new ResourceManager(resourceVisual, resourceData);
        resourceVisual.Init(resourceData);
        
        BuildingData buildingData = (BuildingData) DataLoader.LoadOrCreateData(FileType.Buildings);
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(resourceManager);
        BuildingManager buildingManager = new BuildingManager(buildingEffectManager, buildingData);
        buildingVisual.Init(buildingData, buildingManager);
    }
}