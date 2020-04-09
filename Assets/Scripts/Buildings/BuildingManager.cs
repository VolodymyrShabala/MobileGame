namespace Buildings {
    public class BuildingManager {
        private readonly BuildingData buildingData;
        
        // TODO: Maybe move this to the Building struct. It can manage those things by itself
        private readonly BuildingEffectManager effectManager; 
        
        public BuildingManager(BuildingEffectManager effectManager, BuildingData buildingData) {
            this.effectManager = effectManager;
            this.buildingData = buildingData;
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

        public void Enable(BuildingType buildingType) {
            int buildingIndex = (int) buildingType;
            buildingData.Enable(buildingIndex);
            effectManager.ApplyEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public void Disable(BuildingType buildingType) {
            int buildingIndex = (int) buildingType;
            buildingData.Disable(buildingIndex);
            effectManager.RemoveEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public bool IsUnlocked(BuildingType buildingType) {
            return buildingData.IsUnlocked((int) buildingType);
        }

        public bool InEnoughResources(Building building) {
            return false;
        }
    }
}