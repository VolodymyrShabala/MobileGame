using Resources;

namespace Buildings {
    [System.Serializable]
    public readonly struct BuildingCost {
        public readonly ResourceType resourceType;
        public readonly int amount;

        public BuildingCost(ResourceType resourceType, int amount) {
            this.resourceType = resourceType;
            this.amount = amount;
        }
    }
}