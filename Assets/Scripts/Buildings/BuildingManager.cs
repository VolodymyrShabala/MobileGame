using Resources;
using UnityEngine;

namespace Buildings {
    // TODO: Do I need this class? It does the same things as BuildingData. Maybe combine those two classes together?
    public class BuildingManager {
        private BuildingData buildingData;
        private readonly BuildingVisual buildingVisual;
        private readonly ResourceManager resourceManager; // TODO: Do I really need it here?

        public BuildingManager(BuildingVisual buildingVisual, ResourceManager resourceManager, BuildingData buildingData) {
            this.buildingData = buildingData;
            this.buildingVisual = buildingVisual;
            this.resourceManager = resourceManager;
        }

        public void Build(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (!IsEnoughResources(buildingIndex)) {
                Debug.Log($"Not enough resources to build {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.Build(buildingIndex, amount);
            buildingVisual.UpdateButton(buildingIndex);
        }

        public void Remove(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (buildingData.GetBuilding(buildingIndex).amount < 1) {
                Debug.Log($"There are no buildings to remove in {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.Remove(buildingIndex, amount);
            buildingVisual.UpdateButton(buildingIndex);
        }

        public void Unlock(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (IsUnlocked(buildingIndex)) {
                Debug.Log($"Something went wrong in BuildingManager. Trying to unlock unlocked building at {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
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
                Debug.Log($"Something went wrong in BuildingManager. Trying to enable enabled building at {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.Enable(buildingIndex);
            buildingVisual.UpdateButton(buildingIndex);
        }

        public void Disable(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (!IsEnabled(buildingIndex)) {
                Debug.Log($"Trying to disable disabled building at {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.Disable(buildingIndex);
            buildingVisual.UpdateButton(buildingIndex);
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

            BuildingCost[] buildingCosts = buildingData.GetBuilding(buildingIndex).buildingCosts;
            int length = buildingCosts.Length;

            for (int i = 0; i < length; i++) {
                BuildingCost buildingCost = buildingCosts[i];

                if (!resourceManager.IsEnoughResources(buildingCost.resourceIndex, buildingCost.amount)) {
                    return false;
                }
            }

            return true;
        }

        private bool IsInRange(int buildingIndex) {
            if (buildingIndex >= 0 && buildingIndex < buildingData.Length) {
                return true;
            }

            Debug.Log($"Trying to access index out of range. Index: {buildingIndex}, Max index allowed: {buildingData.Length - 1}. {StackTraceUtility.ExtractStackTrace()}");

            return false;
        }
    }
}