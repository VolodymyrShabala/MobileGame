using System.Collections.Generic;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Buildings.BuildingButton {
    public class BuildingButtonVisual {
        private readonly Building building;
        private readonly ResourceManager resourceManager;
        private readonly BuildingButtonReferenceHolder buttonReferenceHolder;

        private readonly List<TextMeshProUGUI> buildingCostsVisual = new List<TextMeshProUGUI>();
        private readonly List<TextMeshProUGUI> buildingEffectsVisual = new List<TextMeshProUGUI>();

        public BuildingButtonVisual(Building building, ResourceManager resourceManager,
                                    BuildingButtonReferenceHolder buttonReferenceHolder) {
            Assert.IsNotNull(building, "building is null in BuildingButton");
            Assert.IsNotNull(resourceManager, "resourceManager is null in BuildingButton");
            Assert.IsNotNull(buttonReferenceHolder, "buildingButtonHolder is null in BuildingButton");

            this.building = building;
            this.resourceManager = resourceManager;
            this.buttonReferenceHolder = buttonReferenceHolder;

            if (building.IsUnlocked()) {
                Unlock();
            } else {
                buttonReferenceHolder.windowContent.SetActive(false);
            }
            
            SwitchBodyVisibility();
        }

        public void UpdateButton() {
            UpdateNameAndAmount();
            UpdateCost();
        }

        public void UpdateNameAndAmount() {
            buttonReferenceHolder.buildingNameAndAmount.text = $"{building.GetName()} ({building.GetAmount()})";
        }

        public void UpdateDescription() {
            buttonReferenceHolder.buildingDescription.text = building.GetDescription();
        }

        public void UpdateCost() {
            BuildingCost[] buildingCosts = building.GetCosts();
            int length = buildingCosts.Length;
            int index = 0;

            for (int i = 0; i < length; i++) {
                if (buildingCostsVisual.Count <= index) {
                    TextMeshProUGUI resourceName =
                            Object.Instantiate(buttonReferenceHolder.defaultTextPrefab,
                                               buttonReferenceHolder.buildingCostParent);

                    resourceName.text = resourceManager.GetResource(buildingCosts[i].resourceIndex).GetName();
                    buildingCostsVisual.Add(resourceName);

                    TextMeshProUGUI resourceCost =
                            Object.Instantiate(buttonReferenceHolder.defaultTextPrefab,
                                               buttonReferenceHolder.buildingCostParent);

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

        public void UpdateEffect() {
            BuildingEffect[] buildingEffects = building.GetEffects();
            int length = buildingEffects.Length;
            int index = 0;

            for (int i = 0; i < length; i++) {
                if (buildingEffectsVisual.Count <= index) {
                    TextMeshProUGUI effectName = Object.Instantiate(buttonReferenceHolder.defaultTextPrefab,
                                                                    buttonReferenceHolder.buildingEffectParent);

                    effectName.text = resourceManager.GetResource(buildingEffects[i].GetResourceIndex()).GetName();
                    buildingEffectsVisual.Add(effectName);

                    TextMeshProUGUI effectAmount =
                            Object.Instantiate(buttonReferenceHolder.defaultTextPrefab,
                                               buttonReferenceHolder.buildingEffectParent);

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

        public void SetEnable(bool enable) {
            // TODO: Add enable/disable visual
        }

        public void Unlock() {
            buttonReferenceHolder.windowContent.SetActive(true);

            UpdateNameAndAmount();
            UpdateDescription();
            UpdateCost();
            UpdateEffect();
        }

        public void SwitchBodyVisibility() {
            buttonReferenceHolder.body.SetActive(!buttonReferenceHolder.body.activeInHierarchy);
        }
    }
}