using System;
using Buildings;
using Resources;

public static class DataLoader {
    public static object LoadOrCreateData(FileType fileType) {
        object data = FileReader.LoadData(fileType);

        return data ?? CreateData(fileType);
    }

    private static object CreateData(FileType fileType) {
        switch (fileType) {
            case FileType.Resources:
                Resource[] resources = new Resource[1];
                resources[0] = new Resource(ResourceType.Food, 1, 10, 0);
                ResourceData resourceData = new ResourceData(resources);
                return resourceData;
            case FileType.Buildings:
                Building[] buildings = new Building[1];
                buildings[0] = new Building(BuildingType.Farm, "Farm", new BuildingCost[0], 2, new BuildingEffect(), true);
                BuildingData buildingData = new BuildingData(buildings);
                return buildingData;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
        }
    }
}