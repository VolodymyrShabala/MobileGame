using TMPro;
using UnityEngine;

namespace Buildings {
    public class BuildingVisual : MonoBehaviour {
        [SerializeField] private GameObject buildingPrefab;
        private TextMeshProUGUI[] buildingsText; // TODO: Change to a button
        private BuildingData buildingData;
        public void Init(BuildingData buildingData) {
            this.buildingData = buildingData;

            int length = buildingData.GetBuildingsAmount();
            buildingsText = new TextMeshProUGUI[length];
            for (int i = 0; i < length; i++) {
                TextMeshProUGUI text = Instantiate(buildingPrefab, transform).GetComponent<TextMeshProUGUI>();
                Building building = buildingData.GetBuilding((BuildingType) i);

                text.text = $"{building.buildingType.ToString()}: {building.amount}, {building.description}";
                buildingsText[i] = text;
            }
        }
    }
}