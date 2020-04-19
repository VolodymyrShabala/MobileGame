using System;
using Resources;

namespace Buildings {
    [Serializable]
    public abstract class BuildingEffect {
        protected float amount;
        protected int buildingIndex = -1;
        protected int resourceIndex = -1;

        public virtual void Apply(ResourceManager resourceManager) {
        }

        public virtual void Remove(ResourceManager resourceManager) {
        }

        public int GetBuildingIndex() {
            return buildingIndex;
        }

        public int GetResourceIndex() {
            return resourceIndex;
        }

        public float GetAmount() {
            return amount;
        }
    }
}