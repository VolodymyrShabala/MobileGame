namespace Buildings {
    [System.Serializable]
    public struct Building {
        public BuildingType buildingType;
        public string description;
        public BuildingCost[] buildingCosts;
        public int amount;
        public BuildingEffect buildingEffect;
        public bool active;

        public Building(BuildingType buildingType, string description, BuildingCost[] buildingCosts, int amount, BuildingEffect buildingEffect, bool active) {
            this.buildingType = buildingType;
            this.description = description;
            this.buildingCosts = buildingCosts;
            this.amount = amount;
            this.buildingEffect = buildingEffect;
            this.active = active;
        }
    }
    
    public enum BuildingType { Farm, Sawmill }
}