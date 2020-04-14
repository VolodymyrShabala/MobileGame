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

    private BuildingManager buildingManager;
    private Building building;
    private int buildingIndex;
    private ResourceManager resourceManager;

    private bool initialized;

    public void Init(Building building, int buildingIndex, BuildingManager buildingManager,
                     ResourceManager resourceManager) {
        AssertButtonIsReady();

        initialized = true;

        this.buildingManager = buildingManager;
        this.building = building;
        this.buildingIndex = buildingIndex;
        this.resourceManager = resourceManager;

        UpdateText();
        UpdateDescription();
        UpdateCost();
        UpdateEffect();
        AssignBuildButtons();

        collapsibleButton.onClick.AddListener(SwitchBodyVisibility);
        SwitchBodyVisibility();
    }

    // TODO: Change name to Update when MonoBehaviour is removed
    public void UpdateButton() {
        
    }

    private void SwitchBodyVisibility() {
        body.SetActive(!body.activeInHierarchy);
    }

    // TODO: Need to update cost too 
    private void Build() {
        buildingManager.Build(buildingIndex, 1);
        UpdateText();
    }

    private void UpdateText() {
        buildingNameAndAmount.text = $"{building.name} ({building.amount})";
    }

    private void UpdateDescription() {
        buildingDescription.text = building.description;
    }

    private void UpdateCost() {
        int length = building.buildingCosts.Length;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    resourceManager.GetResource(building.buildingCosts[i].resourceIndex).name;

            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingCosts[i].amount.ToString();
        }
    }

    private void UpdateEffect() {
        int length = building.buildingEffects.Length;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingEffectParent).GetComponent<TextMeshProUGUI>().text =
                    resourceManager.GetResource(building.buildingEffects[i].resourceIndex).name;

            Instantiate(defaultTextPrefab, buildingEffectParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingEffects[i].amount.ToString();
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
}