using Buildings.BuildingButton;
using Resources;
using UnityEngine;
using UnityEngine.Assertions;

namespace Buildings {
    public class BuildingVisual {
        public BuildingVisual(BuildingManager buildingManager, ResourceManager resourceManager,
                              BuildingButtonReferenceHolder buildingButtonReferencePrefab, Transform parent) {
            Assert.IsNotNull(buildingManager, "No buildingManager is assigned in BuildingVisual.");
            Assert.IsNotNull(resourceManager, "No resourceManager is assigned in BuildingVisual.");
            Assert.IsNotNull(buildingButtonReferencePrefab, "No buildingButtonPrefab is assigned in BuildingVisual.");
            Assert.IsNotNull(parent, "No parent is assigned in BuildingVisual.");

            CreateBuildingButtons(buildingManager, resourceManager, buildingButtonReferencePrefab, parent);
        }

        private void CreateBuildingButtons(BuildingManager buildingManager, ResourceManager resourceManager,
                                           BuildingButtonReferenceHolder buildingButtonReferencePrefab, Transform parent) {
            int length = buildingManager.GetBuildingsAmount();

            for (int i = 0; i < length; i++) {
                BuildingButtonManager buildingButtonManager =
                        new BuildingButtonManager(buildingManager.GetBuilding(i), resourceManager, buildingButtonReferencePrefab,
                                           parent);
            }
        }
    }
}