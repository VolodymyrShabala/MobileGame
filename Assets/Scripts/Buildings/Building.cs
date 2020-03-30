namespace Buildings {
    [System.Serializable]
    public struct Building {
        public readonly BuildingType buildingType;
        public string description;
        public BuildingCost[] buildingCosts;
        public int amount;
        public BuildingEffect buildingEffect;
        public bool active;
        public bool unlocked;

        public Building(BuildingType buildingType, string description, BuildingCost[] buildingCosts, int amount, BuildingEffect buildingEffect, bool active, bool unlocked = false) {
            this.buildingType = buildingType;
            this.description = description;
            this.buildingCosts = buildingCosts;
            this.amount = amount;
            this.buildingEffect = buildingEffect;
            this.active = active;
            this.unlocked = unlocked;
        }
    }
    
    public enum BuildingType { Farm, Sawmill, MAX }
}