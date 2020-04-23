using Resources;
using UnityEngine;

namespace Buildings {
    public class BuildingManager {
        private readonly Building[] buildings;
        private readonly ResourceManager resourceManager;

        public BuildingManager(Building[] buildings, ResourceManager resourceManager) {
            this.buildings = buildings;
            this.resourceManager = resourceManager;
        }

        public void Build(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex) || !IsEnoughResources(buildingIndex)) {
                return;
            }

            buildings[buildingIndex].Build(amount);
        }

        public void Remove(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex) || buildings[buildingIndex].GetAmount() < 1) {
                return;
            }

            buildings[buildingIndex].Remove(amount);
        }

        public void SetEnabled(int buildIndex, bool enabled) {
            if (!IsInRange(buildIndex)) {
                return;
            }
            
            buildings[buildIndex].SetEnabled(enabled);
        }

        public void Unlock(int buildingIndex) {
            if (!IsInRange(buildingIndex) || IsUnlocked(buildingIndex)) {
                return;
            }

            buildings[buildingIndex].Unlock();
        }

        private bool IsEnabled(int buildingIndex) {
            return IsInRange(buildingIndex) && buildings[buildingIndex].IsEnabled();
        }

        private bool IsUnlocked(int buildingIndex) {
            return IsInRange(buildingIndex) && buildings[buildingIndex].IsUnlocked();
        }

        // TODO: Need to think about how to do this
        private bool IsEnoughResources(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return false;
            }

            BuildingCost[] buildingCosts = buildings[buildingIndex].GetCosts();
            int length = buildingCosts.Length;

            for (int i = 0; i < length; i++) {
                BuildingCost buildingCost = buildingCosts[i];

                if (!resourceManager.IsEnoughResources(buildingCost.resourceIndex, buildingCost.amount)) {
                    return false;
                }
            }

            return true;
        }

        public int GetBuildingsAmount() {
            return buildings.Length;
        }

        public Building GetBuilding(int buildingIndex) {
            return !IsInRange(buildingIndex) ? null : buildings[buildingIndex];
        }

        private bool IsInRange(int buildingIndex) {
            if (buildingIndex >= 0 && buildingIndex < GetBuildingsAmount()) {
                return true;
            }

            Debug.Log($"Trying to access index out of range. Index: {buildingIndex}, Max index allowed: {GetBuildingsAmount() - 1}. {StackTraceUtility.ExtractStackTrace()}");

            return false;
        }
    }
}