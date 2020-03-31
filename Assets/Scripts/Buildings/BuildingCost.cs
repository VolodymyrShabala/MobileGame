using Resources;

namespace Buildings {
    [System.Serializable]
    public readonly struct BuildingCost {
        public readonly ResourceType resourceType;
        public readonly float amount;

        public BuildingCost(ResourceType resourceType, float amount) {
            this.resourceType = resourceType;
            this.amount = amount;
        }
    }
}