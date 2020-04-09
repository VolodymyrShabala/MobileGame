using UnityEngine;

// TODO: This class only spawns building buttons right now. Maybe change its name then?
namespace Buildings {
    public class BuildingVisual : MonoBehaviour {
        [SerializeField] private BuildingButton buildingButtonPrefab;
        private BuildingButton[] buildingButtons;
        private BuildingData buildingData;
        private BuildingManager buildingManager;
        private bool initialized;
        
        public void Init(BuildingData buildingData, BuildingManager buildingManager) {
            if (!buildingButtonPrefab) {
                Debug.LogError($"No buildingButtonPrefab is assigned in {name}. Aborting game startup.");
                return;
            }

            if (initialized) {
                Debug.LogError($"Trying to initialize already initialized class in {name}.");
                return;
            }
            
            initialized = true;

            this.buildingManager = buildingManager;
            this.buildingData = buildingData;

            CreateBuildingButtons(buildingManager);
        }

        private void CreateBuildingButtons(BuildingManager buildingManager) {
            int length = buildingData.Length;
            buildingButtons = new BuildingButton[length];
            
            for (int i = 0; i < length; i++) {
                if (!buildingData.IsUnlocked(i)) {
                    continue;
                }
                
                buildingButtons[i] = Instantiate(buildingButtonPrefab, transform);
                buildingButtons[i].Init(buildingData.GetBuilding(i), i, buildingManager);
            }
        }

        // TODO: Need to check that this will put the button where I want it to be
        public void Unlock(int buildingIndex) {
            if (!initialized) {
                Debug.Log($"{name} has not been initialized.");
                return;
            }
            
            buildingButtons[buildingIndex] = Instantiate(buildingButtonPrefab, transform);
            buildingButtons[buildingIndex].Init(buildingData.GetBuilding(buildingIndex), buildingIndex, buildingManager);
        }
    }
}