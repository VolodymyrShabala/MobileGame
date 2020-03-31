using System.Globalization;
using Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI buildingName;
    [SerializeField] private TextMeshProUGUI buildingDescription;
    [SerializeField] private Transform buildingCostParent;
    [SerializeField] private Transform buildingEffectParent;
    [SerializeField] private Button buildButton;
    [SerializeField] private TextMeshProUGUI defaultTextPrefab;

    [Header("For collapsing")]
    [SerializeField] private Button collapsibleButton;
    [SerializeField] private GameObject body;

    public void Init(Building building) {
        if (!buildingName || !buildingDescription || !buildingCostParent || !buildingCostParent ||
            !buildingEffectParent || !buildButton || !defaultTextPrefab) {
            Debug.LogError($"One of the fields exposed to inspector has not been assigned in {name}. Aborting game startup.");
            return;
        }

        buildingName.text = $"{building.buildingType} ({building.amount})";
        buildingDescription.text = building.description;

        int length = building.buildingCosts.Length;
        CultureInfo currentCulture = CultureInfo.CurrentCulture;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingCosts[i].resourceType.ToString();

            Instantiate(defaultTextPrefab, buildingCostParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingCosts[i].amount.ToString(currentCulture);
        }

        length = building.buildingEffects.Length;

        for (int i = 0; i < length; i++) {
            Instantiate(defaultTextPrefab, buildingEffectParent).GetComponent<TextMeshProUGUI>().text =
                    building.buildingEffects[i].test;
        }
        
        collapsibleButton.onClick.AddListener(CollapseBody);
        CollapseBody();
    }

    private void CollapseBody() {
        body.SetActive(!body.activeInHierarchy);
    }
}