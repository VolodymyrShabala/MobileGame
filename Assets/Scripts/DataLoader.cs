using System;
using Buildings;
using Resources;

public static class DataLoader {
    public static object LoadOrCreateData(FileType fileType) {
        object data = FileReader.LoadData(fileType);

        return data ?? CreateData(fileType);
    }

    // TODO: Change to read from file
    private static object CreateData(FileType fileType) {
        switch (fileType) {
            case FileType.Resources:
                int length = (int) ResourceType.MAX;
                Resource[] resources = new Resource[length];
                resources[0] = new Resource(0, 0, 10, 0, true);

                for (int i = 1; i < length; i++) {
                    resources[i] = new Resource((ResourceType) i, 0, 0, 0, false);
                }

                ResourceData resourceData = new ResourceData(resources);
                return resourceData;
            case FileType.Buildings:
                length = (int) BuildingType.MAX;
                Building[] buildings = new Building[length];
                BuildingEffect[] effects = new BuildingEffect[1];
                effects[0] = new BuildingEffect(BuildingEffectType.IncreaseResourceProduction, ResourceType.Food, 10);
                buildings[0] = new Building(BuildingType.Farm, "Farm", new BuildingCost[0], 0, effects, true);

                for (int i = 1; i < length; i++) {
                    buildings[i] = new Building((BuildingType) i, $"Building {i}", new BuildingCost[0], 0,
                                                new BuildingEffect[0], false);
                }

                BuildingData buildingData = new BuildingData(buildings);
                return buildingData;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
        }
    }
}