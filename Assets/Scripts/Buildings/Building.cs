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

        public Building(string name, string description, BuildingCost[] buildingCosts, BuildingEffect[] buildingEffects,
                        int amount = 0, bool enabled = true, bool unlocked = false) {
            this.name = name;
            this.description = description;
            this.buildingCosts = buildingCosts;
            this.buildingEffects = buildingEffects;
            this.amount = amount;
            this.enabled = enabled;
            this.unlocked = unlocked;
        }
    }
}