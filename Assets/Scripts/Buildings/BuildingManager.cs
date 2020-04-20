﻿using UnityEngine;

namespace Buildings {
    public class BuildingManager {
        private readonly BuildingData buildingData;
        // private readonly ResourceManager resourceManager;

        public BuildingManager(BuildingData buildingData) {
            this.buildingData = buildingData;
        }

        public void Build(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (!IsEnoughResources(buildingIndex)) {
                Debug.Log($"Not enough resources to build {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.buildings[buildingIndex].Build(amount);
        }

        public void Remove(int buildingIndex, int amount = 1) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (buildingData.buildings[buildingIndex].GetAmount() < 1) {
                Debug.Log($"There are no buildings to remove in {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.buildings[buildingIndex].Remove(amount);
        }

        public void Unlock(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (IsUnlocked(buildingIndex)) {
                Debug.Log($"Trying to unlock unlocked building at {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.buildings[buildingIndex].Unlock();
        }

        public void Enable(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (IsEnabled(buildingIndex)) {
                Debug.Log($"Trying to enable enabled building at {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.buildings[buildingIndex].SetEnabled(true);
        }

        public void Disable(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return;
            }

            if (!IsEnabled(buildingIndex)) {
                Debug.Log($"Trying to disable disabled building at {buildingIndex}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            buildingData.buildings[buildingIndex].SetEnabled(false);
        }

        public bool IsUnlocked(int buildingIndex) {
            if (!IsInRange(buildingIndex))
                return false;

            return buildingData.buildings[buildingIndex].IsUnlocked();
        }

        private bool IsEnabled(int buildingIndex) {
            return IsInRange(buildingIndex) && buildingData.buildings[buildingIndex].IsEnabled();
        }

        // TODO: Need to think about how to do this
        private bool IsEnoughResources(int buildingIndex) {
            if (!IsInRange(buildingIndex)) {
                return false;
            }

            // BuildingCost[] buildingCosts = buildings[buildingIndex].GetCosts();
            // int length = buildingCosts.Length;

            // for (int i = 0; i < length; i++) {
            // BuildingCost buildingCost = buildingCosts[i];

            // if (!resourceManager.IsEnoughResources(buildingCost.resourceIndex, buildingCost.amount)) {
            //     return false;
            // }
            // }

            return true;
        }

        public int GetBuildingsAmount() {
            return buildingData.buildings.Length;
        }

        public Building GetBuilding(int buildingIndex) {
            return !IsInRange(buildingIndex) ? null : buildingData.buildings[buildingIndex];
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