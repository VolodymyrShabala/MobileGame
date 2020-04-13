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
    private int buildingIndex;

    private bool initialized;

    public void Init(Building building, int buildingIndex, BuildingManager buildingManager) {
        if (!buildingNameAndAmount || !buildingDescription || !buildingCostParent || !buildingCostParent ||
            !buildingEffectParent || buildButtons.Length == 0 || !defaultTextPrefab) {
            Debug.LogError($"One of the fields exposed to inspector has not been assigned in {name}. Aborting game startup.");
            return;
        }
        
        UnityEngine.Assertions.Assert.IsTrue(initialized);
        initialized = true;

        this.buildingManager = buildingManager;
        this.building = building;
        this.buildingIndex = buildingIndex;
        
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
                    building.buildingCosts[i].resourceIndex.ToString(); // TODO: Need to get resource from index to name

            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingCosts[i].amount.ToString();
        }
    }

    private void UpdateEffect() {
        int length = building.buildingEffects.Length;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingEffectParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingEffects[i].resourceIndex.ToString();
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
}