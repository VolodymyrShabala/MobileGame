using System.Globalization;
using Buildings;
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

    public void Init(Building building, BuildingManager buildingManager) {
        if (!buildingNameAndAmount || !buildingDescription || !buildingCostParent || !buildingCostParent ||
            !buildingEffectParent || buildButtons.Length == 0 || !defaultTextPrefab) {
            Debug.LogError($"One of the fields exposed to inspector has not been assigned in {name}. Aborting game startup.");
            return;
        }

        this.buildingManager = buildingManager;
        this.building = building;

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
    }

    private void Build() {
        buildingManager.Build(building.buildingType, 1);
        UpdateText();
    }

    private void UpdateText() {
        buildingNameAndAmount.text = $"{building.buildingType} ({building.amount})";
    }

    private void UpdateDescription() {
        buildingDescription.text = building.description;
    }

    private void UpdateCost() {
        int length = building.buildingCosts.Length;
        CultureInfo currentCulture = CultureInfo.CurrentCulture;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingCosts[i].resourceType.ToString();

            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingCosts[i].amount.ToString(currentCulture);
        }
    }

    private void UpdateEffect() {
        int length = building.buildingEffects.Length;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingEffectParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingEffects[i].ToString();
        }
    }

    private void AssignBuildButtons() {
        int length = buildButtons.Length;

        for (int i = 0; i < length; i++) {
            buildButtons[i].onClick.AddListener(Build);
        }
    }
}