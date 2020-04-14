using Resources;
using UnityEngine;

// TODO: This class only spawns building buttons right now. Maybe change its name then?
namespace Buildings {
    public class BuildingVisual : MonoBehaviour {
        [SerializeField] private BuildingButton buildingButtonPrefab;
        private BuildingButton[] buildingButtons;
        private BuildingData buildingData; // TODO: Think about changing this to a buildingManager
        private BuildingManager buildingManager;
        private ResourceManager resourceManager; // TODO: Think about if I should have it here? Used for buttons
        private bool initialized;
        
        public void Init(BuildingData buildingData, BuildingManager buildingManager, ResourceManager resourceManager) {
            UnityEngine.Assertions.Assert.IsNotNull(buildingButtonPrefab, $"No buildingButtonPrefab is assigned in {name}.");
            UnityEngine.Assertions.Assert.IsFalse(initialized, $"Trying to initialize already initialized class in {name}.");

            initialized = true;

            this.buildingManager = buildingManager;
            this.buildingData = buildingData;
            this.resourceManager = resourceManager;

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
                buildingButtons[i].Init(buildingData.GetBuilding(i), i, buildingManager, resourceManager);
            }
        }

        // TODO: Need to check that this will put the button where I want it to be
        public void Unlock(int buildingIndex) {
            if (!initialized) {
                Debug.Log($"{name} has not been initialized.");
                return;
            }
            
            buildingButtons[buildingIndex] = Instantiate(buildingButtonPrefab, transform);
            buildingButtons[buildingIndex].Init(buildingData.GetBuilding(buildingIndex), buildingIndex, buildingManager, resourceManager);
        }

        public void UpdateButton(int buildingIndex) {
            buildingButtons[buildingIndex].UpdateButton();
        }
    }
}