using Buildings;
using Resources;
using TMPro;
using UnityEngine;
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

    public void Init(Building building, int buildingIndex, BuildingManager buildingManager, ResourceManager resourceManager) {
        AssertButtonReady();

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

    private void SwitchBodyVisibility() {
        body.SetActive(!body.activeInHierarchy);
        // GetComponentInParent<Canvas>().gameObject.SetActive(false);
        // GetComponentInParent<Canvas>().gameObject.SetActive(true);
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

    private void AssertButtonReady() {
        UnityEngine.Assertions.Assert.IsNotNull(buildingNameAndAmount);
        UnityEngine.Assertions.Assert.IsNotNull(buildingDescription);
        UnityEngine.Assertions.Assert.IsNotNull(buildingCostParent);
        UnityEngine.Assertions.Assert.IsNotNull(buildingEffectParent);
        UnityEngine.Assertions.Assert.IsNotNull(defaultTextPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(collapsibleButton);
        UnityEngine.Assertions.Assert.IsNotNull(body);
        UnityEngine.Assertions.Assert.IsFalse(buildButtons.Length == 0);
        UnityEngine.Assertions.Assert.IsFalse(initialized);
    }
}