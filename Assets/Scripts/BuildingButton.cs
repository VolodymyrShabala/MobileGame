using System.Collections.Generic;
using Buildings;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI buildingNameAndAmount;
    [SerializeField] private TextMeshProUGUI buildingDescription;
    [SerializeField] private Transform buildingCostParent;
    [SerializeField] private Transform buildingEffectParent;
    [SerializeField] private Button[] buildButtons;
    [SerializeField] private TextMeshProUGUI defaultTextPrefab;

    [Header("For collapsing")]
    [SerializeField] private Button collapsibleButton;
    [SerializeField] private GameObject body;

    private Building building;
    private ResourceManager resourceManager;
    private List<TextMeshProUGUI> buildingCostsVisual = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> buildingEffectsVisual = new List<TextMeshProUGUI>();

    private bool initialized;

    public void Init(Building building, ResourceManager resourceManager) {
        AssertButtonIsReady();

        initialized = true;
        

        this.building = building;
        this.resourceManager = resourceManager;
        SubscribeToDelegates();

        UpdateText();
        UpdateDescription();
        UpdateCost();
        UpdateEffect();
        AssignBuildButtons();

        collapsibleButton.onClick.AddListener(SwitchBodyVisibility);
        SwitchBodyVisibility();
    }

    private void UpdateButton() {
        UpdateText();
    }

    private void SwitchBodyVisibility() {
        body.SetActive(!body.activeInHierarchy);
    }

    // TODO: Need to update cost too 
    private void Build() {
        building.Build();
        UpdateText();
    }

    private void UpdateText() {
        buildingNameAndAmount.text = $"{building.GetName()} ({building.GetAmount()})";
    }

    private void UpdateDescription() {
        buildingDescription.text = building.GetDescription();
    }

    // Separate to a different class
    private void UpdateCost() {
        BuildingCost[] buildingCosts = building.GetCosts();
        int length = buildingCosts.Length;

        for (int i = 0; i < length; i++) {
            TextMeshProUGUI resourceName = Instantiate(defaultTextPrefab, buildingCostParent);
            resourceName.text = resourceManager.GetResource(buildingCosts[i].resourceIndex).GetName();
            buildingCostsVisual.Add(resourceName);

            TextMeshProUGUI resourceCost = Instantiate(defaultTextPrefab, buildingCostParent);
            resourceCost.text = buildingCosts[i].amount.ToString();
            buildingCostsVisual.Add(resourceCost);
        }
    }

    private void UpdateEffect() {
        BuildingEffect[] buildingEffects = building.GetEffects();
        int length = buildingEffects.Length;
        
        for (int i = 0; i < length; i++) {
            TextMeshProUGUI effectName = Instantiate(defaultTextPrefab, buildingEffectParent);
            effectName.text = resourceManager.GetResource(buildingEffects[i].GetResourceIndex()).GetName();
            buildingEffectsVisual.Add(effectName);

            TextMeshProUGUI effectAmount = Instantiate(defaultTextPrefab, buildingEffectParent);
            effectAmount.text = buildingEffects[i].GetAmount().ToString();
            
            buildingEffectsVisual.Add(effectAmount);
        }
    }

    private void AssignBuildButtons() {
        int length = buildButtons.Length;

        for (int i = 0; i < length; i++) {
            buildButtons[i].onClick.AddListener(Build);
        }
    }

    private void AssertButtonIsReady() {
        Assert.IsNotNull(buildingNameAndAmount, $"buildingNameAndAmount isn't assigned in {name}.");
        Assert.IsNotNull(buildingDescription, $"buildingDescription isn't assigned in {name}.");
        Assert.IsNotNull(buildingCostParent, $"buildingCostParent isn't assigned in {name}.");
        Assert.IsNotNull(buildingEffectParent, $"buildingEffectParent isn't assigned in {name}.");
        Assert.IsNotNull(defaultTextPrefab, $"defaultTextPrefab isn't assigned in {name}.");
        Assert.IsNotNull(collapsibleButton, $"collapsibleButton isn't assigned in {name}.");
        Assert.IsNotNull(body, $"body isn't assigned in {name}.");
        Assert.IsFalse(buildButtons.Length == 0, $"buildButtons aren't assigned in {name}.");
        Assert.IsFalse(initialized, $"Trying to initialize button when it is already initialized in {name}");
    }

    private void SubscribeToDelegates() {
        building.onBuild += UpdateButton;
        building.onCostUpdated += UpdateCost;
        building.onEffectsUpdated += UpdateEffect;
    }

    private void UnsubscribeFromDelegates() {
        building.onBuild -= UpdateButton;
        building.onCostUpdated -= UpdateCost;
        building.onEffectsUpdated -= UpdateEffect;
    }

    // TODO: Need to think about how this is going to work. Do I need OnEnable too?
    private void OnDisable() {
        UnsubscribeFromDelegates();
    }
}