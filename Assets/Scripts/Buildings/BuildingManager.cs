namespace Buildings {
    public class BuildingManager {
        private BuildingVisual buildingVisual;
        private readonly BuildingData buildingData;
        private readonly BuildingEffectManager effectManager;

        public BuildingManager(BuildingVisual buildingVisual, BuildingEffectManager effectManager, BuildingData buildingData) {
            this.buildingVisual = buildingVisual;
            this.effectManager = effectManager;
            this.buildingData = buildingData;

            // TODO: Bootstrap should initialize this
            buildingVisual.Init(buildingData, this);
        }

        public void Build(BuildingType buildingType, int amount = 1) {
            int buildingIndex = (int) buildingType;
            buildingData.Build(buildingIndex, amount);
            effectManager.ApplyEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }
        
        public void Remove(BuildingType buildingType, int amount = 1) {
            buildingData.Remove((int) buildingType, amount);
        }
        
        public void Unlock(BuildingType buildingType) {
            buildingData.Unlock((int) buildingType);
        }
        
        public bool IsUnlocked(BuildingType buildingType) {
            return buildingData.IsUnlocked((int) buildingType);
        }

        public bool InEnoughResources(Building building) {
            return false;
        }
    }
}