using Resources;

namespace Buildings {
    [System.Serializable]
    public class BuildingEffect {
        protected int buildingIndex = -1;
        protected int resourceIndex = -1;
        protected float amount;

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