namespace Buildings {
    [System.Serializable]
    public struct BuildingEffect {
        public BuildingEffectType effectType; // TODO: Remove
        public int resourceIndex;
        public float amount;

        public BuildingEffect(BuildingEffectType effectType, int resourceIndex, float amount) {
            this.effectType = effectType;
            this.resourceIndex = resourceIndex;
            this.amount = amount;
        }

        public override string ToString() {
            return "";
        }
    }

    // TODO: I think population can be a separate resource type
    // TODO: ConsumeResource and DecreaseResourceProduction is the same. Maybe is fine if I want to have more info available to the player
    // TODO: IncreaseResourceProduction and DecreaseResourceConsumption is the same.
    public enum BuildingEffectType {
        None, UnlockResource, ProduceResource, ConsumeResource, IncreaseResourceProduction, DecreaseResourceProduction,
        DecreaseResourceConsumption, IncreasePopulation, IncreaseResourceStorage, BoostBuildingProduction
    }
}