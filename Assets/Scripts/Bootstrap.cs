using Buildings;
using Resources;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private ResourceVisual resourceVisual;
    [SerializeField] private BuildingVisual buildingVisual;
    
    private void Start() {
        if (!resourceVisual || !buildingVisual) {
            Debug.LogError("One of the exposed fields are not assigned in the inspector. Aborting game start.");
            return;
        }
        
        GameSave gameSave =  DataLoader.LoadOrCreateGame();
        ResourceManager resourceManager = new ResourceManager(resourceVisual, gameSave.resourceData);
        resourceVisual.Init(gameSave.resourceData);
        
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(resourceManager);
        BuildingManager buildingManager = new BuildingManager(buildingEffectManager, buildingVisual, gameSave.resourceData, gameSave.buildingData);
        buildingVisual.Init(gameSave.buildingData, buildingManager);
    }
}