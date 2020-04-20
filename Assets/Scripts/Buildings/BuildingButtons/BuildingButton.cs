using System.Collections.Generic;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Buildings.BuildingButtons {
    public class BuildingButton {
        private readonly Building building;
        private readonly List<TextMeshProUGUI> buildingCostsVisual = new List<TextMeshProUGUI>();
        private readonly List<TextMeshProUGUI> buildingEffectsVisual = new List<TextMeshProUGUI>();
        private readonly BuildingButtonHolder buttonHolder;
        private readonly ResourceManager resourceManager;

        public BuildingButton(Building building, ResourceManager resourceManager, BuildingButtonHolder buttonHolderPrefab,
                              Transform parent) {
            Assert.IsNotNull(building, "building is null in BuildingButton");
            Assert.IsNotNull(resourceManager, "resourceManager is null in BuildingButton");
            Assert.IsNotNull(buttonHolderPrefab, "buildingButtonHolder is null in BuildingButton");
            Assert.IsNotNull(parent, "parent is null in BuildingButton");

            buttonHolder = Object.Instantiate(buttonHolderPrefab, parent);
            buttonHolder.Init();

            this.building = building;
            this.resourceManager = resourceManager;

            SubscribeToDelegates();
            AssignBuildButtons();

            if (!building.IsUnlocked()) {
                buttonHolder.windowContent.SetActive(false);
                return;
            }

            UpdateText();
            UpdateDescription();
            UpdateCost();
            UpdateEffect();
        }

        private void UpdateButton() {
            UpdateText();
            UpdateCost();
        }

        private void UpdateText() {
            buttonHolder.buildingNameAndAmount.text = $"{building.GetName()} ({building.GetAmount()})";
        }

        private void UpdateDescription() {
            buttonHolder.buildingDescription.text = building.GetDescription();
        }

        private void UpdateCost() {
            BuildingCost[] buildingCosts = building.GetCosts();
            int length = buildingCosts.Length;
            int index = 0;

            for (int i = 0; i < length; i++) {
                if (buildingCostsVisual.Count <= index) {
                    TextMeshProUGUI resourceName =
                            Object.Instantiate(buttonHolder.defaultTextPrefab, buttonHolder.buildingCostParent);

                    resourceName.text = resourceManager.GetResource(buildingCosts[i].resourceIndex).GetName();
                    buildingCostsVisual.Add(resourceName);

                    TextMeshProUGUI resourceCost =
                            Object.Instantiate(buttonHolder.defaultTextPrefab, buttonHolder.buildingCostParent);

                    resourceCost.text = buildingCosts[i].amount.ToString();
                    buildingCostsVisual.Add(resourceCost);
                } else {
                    buildingCostsVisual[index].text =
                            resourceManager.GetResource(buildingCosts[i].resourceIndex).GetName();

                    buildingCostsVisual[index + 1].text = buildingCosts[i].amount.ToString();
                }

                index += 2;
            }
        }

        private void UpdateEffect() {
            BuildingEffect[] buildingEffects = building.GetEffects();
            int length = buildingEffects.Length;
            int index = 0;

            for (int i = 0; i < length; i++) {
                if (buildingEffectsVisual.Count <= index) {
                    TextMeshProUGUI effectName =
                            Object.Instantiate(buttonHolder.defaultTextPrefab, buttonHolder.buildingEffectParent);

                    effectName.text = resourceManager.GetResource(buildingEffects[i].GetResourceIndex()).GetName();
                    buildingEffectsVisual.Add(effectName);

                    TextMeshProUGUI effectAmount =
                            Object.Instantiate(buttonHolder.defaultTextPrefab, buttonHolder.buildingEffectParent);

                    effectAmount.text = buildingEffects[i].GetAmount().ToString();

                    buildingEffectsVisual.Add(effectAmount);
                } else {
                    buildingEffectsVisual[index].text =
                            resourceManager.GetResource(buildingEffects[i].GetResourceIndex()).GetName();

                    buildingEffectsVisual[index + 1].text = buildingEffects[i].GetAmount().ToString();
                }

                index += 2;
            }
        }

        private void SetEnable(bool enable) {
            // TODO: Add enable/disable visual
        }

        private void Unlock() {
            buttonHolder.windowContent.SetActive(true);
            UpdateText();
            UpdateDescription();
            UpdateCost();
            UpdateEffect();
        }

        private void AssignBuildButtons() {
            int length = buttonHolder.buildButtons.Length;

            for (int i = 0; i < length; i++)
                buttonHolder.buildButtons[i].onClick.AddListener(() => building.Build());
        }

        private void SubscribeToDelegates() {
            building.onBuild += UpdateButton;
            building.onCostUpdated += UpdateCost;
            building.onEffectsUpdated += UpdateEffect;
            building.onEnable += SetEnable;
            building.onUnlock += Unlock;
        }

        private void UnsubscribeFromDelegates() {
            building.onBuild -= UpdateButton;
            building.onCostUpdated -= UpdateCost;
            building.onEffectsUpdated -= UpdateEffect;
            building.onEnable -= SetEnable;
            building.onUnlock -= Unlock;
        }
    }
}