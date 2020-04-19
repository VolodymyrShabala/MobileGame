using Resources;

namespace Buildings {
    public class BuildingEffectManager {
        private static bool initialized;

        private static BuildingEffectManager instance;
        private readonly ResourceManager resourceManager;

        public BuildingEffectManager(ResourceManager resourceManager) {
            this.resourceManager = resourceManager;
            instance = this;
            initialized = true;
        }

        public static BuildingEffectManager Instance => initialized ? instance : null;

        public void ApplyEffects(BuildingEffect[] effects) {
            int length = effects.Length;

            for (int i = 0; i < length; i++)
                effects[i].Apply(resourceManager);
        }

        public void RemoveEffects(BuildingEffect[] effects) {
            int length = effects.Length;

            for (int i = 0; i < length; i++)
                effects[i].Remove(resourceManager);
        }
    }
}