namespace Buildings {
    [System.Serializable]
    public struct BuildingCost { // TODO: Make readonly
        public int resourceIndex;
        public float amount;

        public BuildingCost(int resourceIndex, float amount) {
            this.resourceIndex = resourceIndex;
            this.amount = amount;
        }
    }
}