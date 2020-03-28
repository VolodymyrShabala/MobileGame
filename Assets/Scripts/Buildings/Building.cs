namespace Buildings {
    public struct Building {
        public BuildingType buildingType;
        public string description;
        public BuildingCost[] buildingCosts;
        public int buildAmount;
        public BuildingEffect buildingEffect;
        public bool active;

        public Building(BuildingType buildingType, string description, BuildingCost[] buildingCosts, int buildAmount, BuildingEffect buildingEffect, bool active) {
            this.buildingType = buildingType;
            this.description = description;
            this.buildingCosts = buildingCosts;
            this.buildAmount = buildAmount;
            this.buildingEffect = buildingEffect;
            this.active = active;
        }
    }
    
    public enum BuildingType { Farm, Sawmill }
}