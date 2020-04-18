using Buildings;
using Resources;

[System.Serializable]
public class GameSave {
    private ResourceManager resourceManager;
    private BuildingManager buildingManager;

    public GameSave(ResourceManager resourceManager, BuildingManager buildingManager) {
        this.resourceManager = resourceManager;
        this.buildingManager = buildingManager;
    }

    public ResourceManager GetResourceManager => resourceManager;
    public BuildingManager GetBuildingManager => buildingManager;
}