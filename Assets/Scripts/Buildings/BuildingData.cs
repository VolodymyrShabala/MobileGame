using UnityEngine;

namespace Buildings {
    public struct BuildingData {
        private Building[] unlockedBuildings; // TODO: Needs to be readonly. List?

        public BuildingData(Building[] unlockedBuildings) {
            this.unlockedBuildings = unlockedBuildings;
        }

        public void Build(BuildingType buildingType, int amount) {
            for (int i = 0; i < unlockedBuildings.Length; i++) {
                if (unlockedBuildings[i].buildingType == buildingType) {
                    unlockedBuildings[i].buildAmount += amount;
                }
            }
        }

        public void Remove(BuildingType buildingType, int amount) {
            for (int i = 0; i < unlockedBuildings.Length; i++) {
                if (unlockedBuildings[i].buildingType == buildingType) {
                    unlockedBuildings[i].buildAmount -= amount;
                }
            }
        }

        public void Unlock(BuildingType buildingType) {
            int length = GetBuildingsAmount();
            Building[] temp = new Building[length + 1];

            for (int i = 0; i < length; i++) {
                temp[i] = unlockedBuildings[i];
            }
            temp[length + 1] = new Building(buildingType, "", new BuildingCost[0], 1, new BuildingEffect(), true);
            unlockedBuildings = temp;
        }
        
        public bool IsUnlocked(BuildingType buildingType) {
            return GetBuilding(buildingType).buildingType == buildingType;
        }
        
        public Building GetBuilding(BuildingType buildingType) {
            for (int i = 0; i < unlockedBuildings.Length; i++) {
                if (unlockedBuildings[i].buildingType == buildingType) {
                    return unlockedBuildings[i];
                }
            }

            Debug.Log($"Trying to access locked building {buildingType}.");
            return default;
        }
        
        public int GetBuildingsAmount() {
            return unlockedBuildings.Length;
        }
    }
}