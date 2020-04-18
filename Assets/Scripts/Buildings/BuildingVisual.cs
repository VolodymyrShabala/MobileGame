using Resources;
using UnityEngine;

namespace Buildings {
    public class BuildingVisual  {
        private BuildingButton[] buildingButtons;
        
        public BuildingVisual(BuildingManager buildingManager, ResourceManager resourceManager, BuildingButton buildingButtonPrefab, Transform parent) {
            UnityEngine.Assertions.Assert.IsNotNull(buildingManager, $"No buildingManager is assigned in BuildingVisual.");
            UnityEngine.Assertions.Assert.IsNotNull(resourceManager, $"No resourceManager is assigned in BuildingVisual.");
            UnityEngine.Assertions.Assert.IsNotNull(buildingButtonPrefab, $"No buildingButtonPrefab is assigned in BuildingVisual.");
            UnityEngine.Assertions.Assert.IsNotNull(parent, $"No parent is assigned in BuildingVisual.");
            
            CreateBuildingButtons(buildingManager, resourceManager, buildingButtonPrefab, parent);
        }

        private void CreateBuildingButtons(BuildingManager buildingManager, ResourceManager resourceManager, BuildingButton buildingButtonPrefab, Transform parent) {
            int length = buildingManager.GetBuildingsAmount();
            buildingButtons = new BuildingButton[length];

            for (int i = 0; i < length; i++) {
                if (!buildingManager.IsUnlocked(i)) {
                    continue;
                }
                
                buildingButtons[i] = Object.Instantiate(buildingButtonPrefab, parent);
                buildingButtons[i].Init(buildingManager.GetBuilding(i), i, buildingManager, resourceManager);
            }
        }
    }
}