using Buildings;
using Resources;

[System.Serializable]
public class GameSave {
    public ResourceData resourceData;
    public BuildingData buildingData;

    public GameSave(ResourceData resourceData, BuildingData buildingData) {
        this.resourceData = resourceData;
        this.buildingData = buildingData;
    }
}