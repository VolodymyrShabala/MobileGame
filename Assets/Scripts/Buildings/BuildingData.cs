namespace Buildings {
    [System.Serializable]
    public struct BuildingData {
        [UnityEngine.SerializeField] private Building[] buildings;

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

        public void Enable(int index) {
            buildings[index].enabled = true;
        }

        public void Disable(int index) {
            buildings[index].enabled = false;
        }

        public bool IsUnlocked(int index) {
            return buildings[index].unlocked;
        }

        public bool IsEnabled(int index) {
            return buildings[index].enabled;
        }
        
        public Building GetBuilding(int index) {
            return buildings[index];
        }

        public int Length => buildings.Length;
    }
}