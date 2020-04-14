using Resources;
using UnityEngine;

namespace Buildings {
    public class BuildingManager {
        private BuildingData buildingData;
        private readonly BuildingVisual buildingVisual;
        private ResourceManager resourceManager; // TODO: Do I really need it here?

        // TODO: Maybe move this to the Building struct. It can manage those things by itself
        private readonly BuildingEffectManager effectManager;

        public BuildingManager(BuildingEffectManager effectManager, BuildingVisual buildingVisual,
                               ResourceManager resourceManager, BuildingData buildingData) {
            this.effectManager = effectManager;
            this.buildingData = buildingData;
            this.buildingVisual = buildingVisual;
            this.resourceManager = resourceManager;
        }

        public void Build(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (!IsEnoughResources(buildingIndex)) {
                Debug.Log($"Not enough resources to build {buildingIndex}.");
                return;
            }

            buildingData.Build(buildingIndex, amount);
            effectManager.ApplyEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public void Remove(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (buildingData.GetBuilding(buildingIndex).amount < 1) {
                Debug.Log($"There are no buildings to remove in {buildingIndex}.");
                return;
            }

            buildingData.Remove(buildingIndex, amount);
        }

        public void Unlock(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (IsUnlocked(buildingIndex)) {
                Debug.Log($"Something went wrong in BuildingManager. Trying to unlock unlocked building at {buildingIndex}.");
                return;
            }

            buildingData.Unlock(buildingIndex);
            buildingVisual.Unlock(buildingIndex);
        }

        public void Enable(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (IsEnabled(buildingIndex)) {
                Debug.Log($"Something went wrong in BuildingManager. Trying to enable enabled building at {buildingIndex}.");
                return;
            }

            buildingData.Enable(buildingIndex);
            effectManager.ApplyEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public void Disable(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (!IsEnabled(buildingIndex)) {
                Debug.Log($"Trying to disable disabled building at {buildingIndex}.");
                return;
            }

            buildingData.Disable(buildingIndex);
            effectManager.RemoveEffects(buildingData.GetBuilding(buildingIndex).buildingEffects);
        }

        public bool IsUnlocked(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return false;
            }

            return buildingData.IsUnlocked(buildingIndex);
        }

        public bool IsEnabled(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return false;
            }

            return buildingData.IsEnabled(buildingIndex);
        }

        public bool IsEnoughResources(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return false;
            }

            Building building = buildingData.GetBuilding(buildingIndex);
            int length = building.buildingCosts.Length;

            // TODO: Save building cost
            for (int i = 0; i < length; i++) {
                if (!resourceManager.InEnoughResources(building.buildingCosts[i].resourceIndex,
                                                       building.buildingCosts[i].amount)) {
                    return false;
                }
            }

            return true;
        }

        private bool IsInRange(int buildingIndex) {
            if (!buildingData.IsInRange(buildingIndex)) {
                Debug.Log($"Trying to access index out of range. Index: {buildingIndex}, Max index allowed: {buildingData.Length - 1}.");
                return false;
            }

            return true;
        }
    }
}