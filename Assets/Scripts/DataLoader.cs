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
                int length = (int) ResourceType.MAX;
                Resource[] resources = new Resource[length];
                resources[0] = new Resource((ResourceType) 0, 0, 10, 0, true);

                for (int i = 1; i < length; i++) {
                    resources[i] = new Resource((ResourceType) i, 0, 0, 0, false);
                }
                
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