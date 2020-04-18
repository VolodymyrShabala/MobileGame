using Resources;

namespace Buildings {
    public class BuildingEffect {
        protected int resourceIndex;
        protected float amount;

        public virtual void Apply(ResourceManager resourceManager) {
        }

        public virtual void Remove(ResourceManager resourceManager) {
        }

        public void ShowBuildingEffectsWindow() {
            
        }
    }
}