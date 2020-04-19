using System;
using Resources;

namespace Buildings.BuildingEffects {
    [Serializable]
    public class IncreaseProduction : BuildingEffect {
        public IncreaseProduction(int resourceIndex = -1, float amount = 0) {
            this.resourceIndex = resourceIndex;
            this.amount = amount;
        }

        public override void Apply(ResourceManager resourceManager) {
            resourceManager.IncreaseProduction(resourceIndex, amount);
        }

        public override void Remove(ResourceManager resourceManager) {
            resourceManager.DecreaseProduction(resourceIndex, amount);
        }
    }
}