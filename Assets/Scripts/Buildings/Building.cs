using Buildings.BuildingEffects;

namespace Buildings {
    [System.Serializable]
    public class Building {
        public string name;
        public string description;
        public BuildingCost[] buildingCosts;
        public BuildingEffect[] buildingEffects;
        public int amount;
        public bool enabled;
        public bool unlocked;

        public Building(string name = "", string description = "", BuildingCost[] buildingCosts = null, BuildingEffect[] buildingEffects = null,
                        int amount = 0, bool enabled = true, bool unlocked = false) {
            this.name = name;
            this.description = description;
            this.buildingCosts = buildingCosts;
            this.buildingEffects = buildingEffects;
            this.amount = amount;
            this.enabled = enabled;
            this.unlocked = unlocked;
        }

        public void Build(int amount = 1) {
            this.amount += amount;
            ApplyBuildingEffects();
        }

        public void Remove(int amount = 1) {
            this.amount -= amount;
            RemoveBuildingEffects();
        }

        private void ApplyBuildingEffects() {
            BuildingEffectManager.Instance.ApplyEffects(buildingEffects);
        }

        private void RemoveBuildingEffects() {
            BuildingEffectManager.Instance.RemoveEffects(buildingEffects);
        }
    }
    public enum BuildingEffectType {
        None, UnlockResource, ProduceResource, ConsumeResource, IncreaseResourceProduction, DecreaseResourceProduction,
        DecreaseResourceConsumption, IncreasePopulation, IncreaseResourceStorage, BoostBuildingProduction
    }
}