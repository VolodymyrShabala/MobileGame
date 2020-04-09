namespace Buildings {
    [System.Serializable]
    public class Building {
        public readonly BuildingType buildingType;
        public string description;
        public BuildingCost[] buildingCosts;
        public int amount;
        public BuildingEffect[] buildingEffects;
        public bool active;
        public bool unlocked;

        public Building(BuildingType buildingType, string description, BuildingCost[] buildingCosts, int amount, BuildingEffect[] buildingEffects, bool active, bool unlocked = false) {
            this.buildingType = buildingType;
            this.description = description;
            this.buildingCosts = buildingCosts;
            this.amount = amount;
            this.buildingEffects = buildingEffects;
            this.active = active;
            this.unlocked = unlocked;
        }
    }
    
    public enum BuildingType { Farm, Sawmill, MAX }
}