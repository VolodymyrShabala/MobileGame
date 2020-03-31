using TMPro;
using UnityEngine;

namespace Buildings {
    public class BuildingVisual : MonoBehaviour {
        [SerializeField] private BuildingButton buildingButtonPrefab;
        private BuildingData buildingData;
        
        public void Init(BuildingData buildingData) {
            if (!buildingButtonPrefab) {
                Debug.LogError($"No buildingButtonPrefab is assigned in {name}. Aborting game startup.");
                return;
            }
            
            this.buildingData = buildingData;

            CreateBuildingButtons();
        }

        private void CreateBuildingButtons() {
            int length = buildingData.GetBuildingsAmount();
            
            for (int i = 0; i < length; i++) {
                if (!buildingData.IsUnlocked(i)) {
                    continue;
                }
                
                Instantiate(buildingButtonPrefab, transform).Init(buildingData.GetBuilding(i));
            }
        }
    }
}