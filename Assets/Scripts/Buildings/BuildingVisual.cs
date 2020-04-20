using Buildings.BuildingButtons;
using Resources;
using UnityEngine;
using UnityEngine.Assertions;

namespace Buildings {
    public class BuildingVisual {
        public BuildingVisual(BuildingManager buildingManager, ResourceManager resourceManager,
                              BuildingButtonHolder buildingButtonPrefab, Transform parent) {
            Assert.IsNotNull(buildingManager, "No buildingManager is assigned in BuildingVisual.");
            Assert.IsNotNull(resourceManager, "No resourceManager is assigned in BuildingVisual.");
            Assert.IsNotNull(buildingButtonPrefab, "No buildingButtonPrefab is assigned in BuildingVisual.");
            Assert.IsNotNull(parent, "No parent is assigned in BuildingVisual.");

            CreateBuildingButtons(buildingManager, resourceManager, buildingButtonPrefab, parent);
        }

        private void CreateBuildingButtons(BuildingManager buildingManager, ResourceManager resourceManager,
                                           BuildingButtonHolder buildingButtonPrefab, Transform parent) {
            int length = buildingManager.GetBuildingsAmount();

            for (int i = 0; i < length; i++) {
                BuildingButton buildingButton =
                        new BuildingButton(buildingManager.GetBuilding(i), resourceManager, buildingButtonPrefab,
                                           parent);
            }
        }
    }
}