using TMPro;
using UnityEngine;

namespace Resources {
    // TODO: Make class pure and remove initialized bool
    public class ResourceVisual : MonoBehaviour {
        [SerializeField] private GameObject resourcePrefab;
        private TextMeshProUGUI[] resourceText;
        private ResourceManager resourceManager;
        private bool initialized;

        // TODO: Move assertions to its own function?
        public void Init(ResourceManager resourceManager) {
            UnityEngine.Assertions.Assert.IsNotNull(resourcePrefab, $"No resourcePrefab is assigned in {name}.");
            UnityEngine.Assertions.Assert.IsFalse(initialized, $"Trying to initialize already initialized class in {name}.");
            initialized = true;
            
            this.resourceManager = resourceManager;
            CreateResourceText();
        }

        public void UpdateResources() {
            if (!initialized) {
                Debug.Log($"{name} has not been initialized. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            int length = resourceManager.GetResourceAmount();

            for (int i = 0; i < length; i++) {
                if (!resourceManager.IsUnlockedResource(i)) {
                    continue;
                }

                resourceText[i].text = resourceManager.GetResource(i).ToString();
            }
        }

        public void UpdateResource(int index) {
            if (!initialized) {
                Debug.Log($"{name} has not been initialized. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            if (!resourceManager.IsUnlockedResource(index)) {
                Debug.Log($"Trying to update locked resource in {name}. {StackTraceUtility.ExtractStackTrace()}");
                return;
            }

            resourceText[index].text = resourceManager.GetResource(index).ToString();
        }

        private void CreateResourceText() {
            int length = resourceManager.GetResourceAmount();
            resourceText = new TextMeshProUGUI[length];

            for (int i = 0; i < length; i++) {
                if (!resourceManager.IsUnlockedResource(i)) {
                    continue;
                }

                TextMeshProUGUI text = Instantiate(resourcePrefab, transform).GetComponent<TextMeshProUGUI>();
                text.text = resourceManager.GetResource(i).ToString();
                resourceText[i] = text;
            }
        }
    }
}