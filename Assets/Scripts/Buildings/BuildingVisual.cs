using UnityEngine;

// TODO: This class only spawns building buttons right now. Maybe change its name then?
namespace Buildings {
    public class BuildingVisual : MonoBehaviour {
        [SerializeField] private BuildingButton buildingButtonPrefab;
        private BuildingButton[] buildingButtons;
        private BuildingData buildingData;
        
        public void Init(BuildingData buildingData, BuildingManager buildingManager) {
            if (!buildingButtonPrefab) {
                Debug.LogError($"No buildingButtonPrefab is assigned in {name}. Aborting game startup.");
                return;
            }
            
            this.buildingData = buildingData;

            CreateBuildingButtons(buildingManager);
        }

        private void CreateBuildingButtons(BuildingManager buildingManager) {
            int length = buildingData.GetBuildingsAmount();
            buildingButtons = new BuildingButton[length];
            
            for (int i = 0; i < length; i++) {
                if (!buildingData.IsUnlocked(i)) {
                    continue;
                }
                
                buildingButtons[i] = Instantiate(buildingButtonPrefab, transform);
                buildingButtons[i].Init(buildingData.GetBuilding(i), buildingManager);
            }
        }
    }
}