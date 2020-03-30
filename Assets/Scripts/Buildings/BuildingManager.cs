namespace Buildings {
    public class BuildingManager {
        private BuildingVisual buildingVisual;
        private BuildingData buildingData;

        public BuildingManager(BuildingVisual buildingVisual, BuildingData buildingData) {
            this.buildingVisual = buildingVisual;
            this.buildingData = buildingData;

            buildingVisual.Init(buildingData);
        }
    }
}