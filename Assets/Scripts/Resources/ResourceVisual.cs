using TMPro;
using UnityEngine;

namespace Resources {
    public class ResourceVisual : MonoBehaviour {
        [SerializeField] private GameObject resourcePrefab;
        private TextMeshProUGUI[] resourceText;
        private ResourceData resourceData;
        private bool initialized;

        public void Init(ResourceData resourceData) {
            if (!resourcePrefab) {
                Debug.LogError($"No resourcePrefab is assigned in {name}. Aborting game startup.");
                return;
            }

            if (initialized) {
                Debug.LogError($"Trying to initialize already initialized class in {name}.");
                return;
            }

            initialized = true;
            this.resourceData = resourceData;
            CreateResourceText();
        }

        public void UpdateResources() {
            if (!initialized) {
                Debug.Log($"{name} has not been initialized.");
                return;
            }

            int length = resourceData.Length;

            for (int i = 0; i < length; i++) {
                if (!resourceData.IsUnlocked(i)) {
                    continue;
                }

                resourceText[i].text = resourceData.GetResource(i).ToString();
            }
        }

        public void UpdateResource(int index) {
            if (!initialized) {
                Debug.Log($"{name} has not been initialized.");
                return;
            }

            if (!resourceData.IsUnlocked(index)) {
                Debug.Log($"Trying to update locked resource in {name}.");
                return;
            }

            resourceText[index].text = resourceData.GetResource(index).ToString();
        }

        private void CreateResourceText() {
            int length = resourceData.Length;
            resourceText = new TextMeshProUGUI[length];

            for (int i = 0; i < length; i++) {
                if (!resourceData.IsUnlocked(i)) {
                    continue;
                }

                TextMeshProUGUI text = Instantiate(resourcePrefab, transform).GetComponent<TextMeshProUGUI>();
                text.text = resourceData.GetResource(i).ToString();
                resourceText[i] = text;
            }
        }
    }
}