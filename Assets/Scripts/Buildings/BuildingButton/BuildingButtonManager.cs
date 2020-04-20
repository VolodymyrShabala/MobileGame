using Resources;
using UnityEngine;
using UnityEngine.Assertions;

namespace Buildings.BuildingButton {
    public class BuildingButtonManager {
        private readonly Building building;
        private readonly BuildingButtonVisual buttonVisual;
        private readonly BuildingButtonReferenceHolder buttonReferenceHolder;

        public BuildingButtonManager(Building building, ResourceManager resourceManager,
                                     BuildingButtonReferenceHolder buttonReferenceHolderPrefab, Transform parent) {
            Assert.IsNotNull(building, "building is null in BuildingButton");
            Assert.IsNotNull(resourceManager, "resourceManager is null in BuildingButton");
            Assert.IsNotNull(buttonReferenceHolderPrefab, "buildingButtonHolder is null in BuildingButton");
            Assert.IsNotNull(parent, "parent is null in BuildingButton");

            this.building = building;

            buttonReferenceHolder = Object.Instantiate(buttonReferenceHolderPrefab, parent);
            buttonReferenceHolder.Init();

            buttonVisual = new BuildingButtonVisual(building, resourceManager, buttonReferenceHolder);

            buttonReferenceHolder.collapsibleButton.onClick.AddListener(buttonVisual.SwitchBodyVisibility);

            SubscribeToDelegates();
            AssignBuildButtons();
        }
        
        private void AssignBuildButtons() {
            int length = buttonReferenceHolder.buildButtons.Length;

            for (int i = 0; i < length; i++)
                buttonReferenceHolder.buildButtons[i].onClick.AddListener(() => building.Build());
        }

        private void SubscribeToDelegates() {
            building.onBuild += buttonVisual.UpdateButton;
            building.onNameUpdate += buttonVisual.UpdateNameAndAmount;
            building.onDescriptionUpdate += buttonVisual.UpdateDescription;
            building.onCostUpdated += buttonVisual.UpdateCost;
            building.onEffectsUpdated += buttonVisual.UpdateEffect;
            building.onEnable += buttonVisual.SetEnable;
            building.onUnlock += buttonVisual.Unlock;
        }

        // TODO: Need to call it when I switch windows.
        private void UnsubscribeFromDelegates() {
            building.onBuild -= buttonVisual.UpdateButton;
            building.onNameUpdate -= buttonVisual.UpdateNameAndAmount;
            building.onDescriptionUpdate -= buttonVisual.UpdateDescription;
            building.onCostUpdated -= buttonVisual.UpdateCost;
            building.onEffectsUpdated -= buttonVisual.UpdateEffect;
            building.onEnable -= buttonVisual.SetEnable;
            building.onUnlock -= buttonVisual.Unlock;
        }
    }
}