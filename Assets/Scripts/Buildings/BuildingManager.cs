using Resources;

namespace Buildings {
    public class BuildingManager {
        private BuildingData buildingData;
        private readonly BuildingVisual buildingVisual;
        private ResourceData resourceData; // TODO: Do I really need it here?

        // TODO: Maybe move this to the Building struct. It can manage those things by itself
        private readonly BuildingEffectManager effectManager;

        public BuildingManager(BuildingEffectManager effectManager, BuildingVisual buildingVisual,
                               ResourceData resourceData, BuildingData buildingData) {
            this.effectManager = effectManager;
            this.buildingData = buildingData;
            this.buildingVisual = buildingVisual;
            this.resourceData = resourceData;
        }

        public void Build(int buildingIndex, int amount = 1) {
            if (!IsEnoughResources(buildingIndex)) {
                UnityEngine.Debug.Log("Not enough resources to build.");
                return;
            }

            buildingData.Build(buildingIndex, amount);
            effectManager.ApplyEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public void Remove(int buildingIndex, int amount = 1) {
            if (buildingData.GetBuilding(buildingIndex).amount < 1) {
                UnityEngine.Debug.Log("There are no buildings to remove.");
                return;
            }

            buildingData.Remove(buildingIndex, amount);
        }

        public void Unlock(int buildingIndex) {
            if (IsUnlocked(buildingIndex)) {
                UnityEngine.Debug.Log("Something went wrong in BuildingManager. Trying to unlock unlocked building.");
                return;
            }

            buildingData.Unlock(buildingIndex);
            buildingVisual.Unlock(buildingIndex);
        }

        public void Enable(int buildingIndex) {
            if (IsEnabled(buildingIndex)) {
                UnityEngine.Debug.Log("Something went wrong in BuildingManager. Trying to enable enabled building.");
                return;
            }

            buildingData.Enable(buildingIndex);
            effectManager.ApplyEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public void Disable(int buildingIndex) {
            if (!IsEnabled(buildingIndex)) {
                UnityEngine.Debug.Log("Trying to disable disabled building.");
                return;
            }

            buildingData.Disable(buildingIndex);
            effectManager.RemoveEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public bool IsUnlocked(int buildingIndex) {
            return buildingData.IsUnlocked(buildingIndex);
        }

        public bool IsEnabled(int buildingIndex) {
            return buildingData.IsEnabled(buildingIndex);
        }

        public bool IsEnoughResources(int buildingIndex) {
            Building building = buildingData.GetBuilding(buildingIndex);
            int length = building.buildingCosts.Length;

            for (int i = 0; i < length; i++) {
                if (!resourceData.IsEnoughResource(building.buildingCosts[i].resourceIndex,
                                                   building.buildingCosts[i].amount)) {
                    return false;
                }
            }

            return true;
        }
    }
}