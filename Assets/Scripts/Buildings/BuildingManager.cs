namespace Buildings {
    public class BuildingManager {
        private BuildingVisual buildingVisual;
        private readonly BuildingData buildingData;

        public BuildingManager(BuildingVisual buildingVisual, BuildingData buildingData) {
            this.buildingVisual = buildingVisual;
            this.buildingData = buildingData;

            buildingVisual.Init(buildingData);
        }

        public void Build(BuildingType buildingType, int amount = 1) {
            buildingData.Build(GetBuildingIndex(buildingType), amount);
        }
        
        public void Remove(BuildingType buildingType, int amount = 1) {
            buildingData.Remove(GetBuildingIndex(buildingType), amount);
        }
        
        public void Unlock(BuildingType buildingType) {
            buildingData.Unlock(GetBuildingIndex(buildingType));
        }
        
        public bool IsUnlocked(BuildingType buildingType) {
            return buildingData.IsUnlocked(GetBuildingIndex(buildingType));
        }

        private int GetBuildingIndex(BuildingType buildingType) {
            int length = buildingData.GetBuildingsAmount();

            for (int i = 0; i < length; i++) {
                if (buildingData.GetBuilding(i).buildingType == buildingType) {
                    return i;
                }
            }
            UnityEngine.Debug.LogError($"Trying to access non existent building type {buildingType}.");

            return -1;
        }
    }
}