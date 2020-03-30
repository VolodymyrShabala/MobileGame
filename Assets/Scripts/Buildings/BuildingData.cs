namespace Buildings {
    [System.Serializable]
    public readonly struct BuildingData {
        private readonly Building[] buildings; // TODO: Needs to be readonly. List?

        public BuildingData(Building[] buildings) {
            this.buildings = buildings;
        }

        public void Build(int index, int amount) {
            buildings[index].amount += amount;
        }

        public void Remove(int index, int amount) {
            buildings[index].amount -= amount;
        }

        public void Unlock(int index) {
            buildings[index].unlocked = true;
        }

        public bool IsUnlocked(int index) {
            return buildings[index].unlocked = true;
        }

        public Building GetBuilding(int index) {
            return buildings[index];
        }

        public int GetBuildingsAmount() {
            return buildings.Length;
        }
    }
}