using System;

namespace Buildings {
    [Serializable]
    public struct BuildingCost {
        public int resourceIndex;
        public float amount;

        public BuildingCost(int resourceIndex, float amount) {
            this.resourceIndex = resourceIndex;
            this.amount = amount;
        }
    }
}