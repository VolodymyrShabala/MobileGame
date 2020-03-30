using TMPro;
using UnityEngine;

namespace Buildings {
    public class BuildingVisual : MonoBehaviour {
        [SerializeField] private GameObject buildingPrefab;
        private TextMeshProUGUI[] buildingsText; // TODO: Change to a button
        private BuildingData buildingData;
        
        public void Init(BuildingData buildingData) {
            if (!buildingPrefab) {
                Debug.LogError($"No buildingPrefab is assigned in {name}. Aborting game startup.");
                return;
            }
            
            this.buildingData = buildingData;

            CreateBuildingButtons();
        }

        private void CreateBuildingButtons() {
            int length = buildingData.GetBuildingsAmount();
            buildingsText = new TextMeshProUGUI[length];
            
            for (int i = 0; i < length; i++) {
                if (!buildingData.IsUnlocked(i)) {
                    continue;
                }
                TextMeshProUGUI text = Instantiate(buildingPrefab, transform).GetComponent<TextMeshProUGUI>();
                Building building = buildingData.GetBuilding(i);

                text.text = $"{building.buildingType.ToString()}: {building.amount}, {building.description}";
                buildingsText[i] = text;
            }
        }
    }
}