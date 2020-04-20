using System;
using Buildings;
using Resources;

[Serializable]
public class GameSave {
    public GameSave(ResourceManager resourceManager, BuildingManager buildingManager) {
        GetResourceManager = resourceManager;
        GetBuildingManager = buildingManager;
    }

    // TODO: Check with saving that it works
    public ResourceManager GetResourceManager { get; }
    public BuildingManager GetBuildingManager { get; }
}