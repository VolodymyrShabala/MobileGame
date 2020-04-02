using TMPro;
using UnityEngine;

namespace Resources {
    public class ResourceVisual : MonoBehaviour {
        [SerializeField] private GameObject resourcePrefab;
        private TextMeshProUGUI[] resourceText;
        private ResourceData resourceData;

        public void Init(ResourceData resourceData) {
            if (!resourcePrefab) {
                Debug.LogError($"No resourcePrefab is assigned in {name}. Aborting game startup.");
                return;
            }

            this.resourceData = resourceData;
            CreateResourceText();
        }

        public void UpdateResources() {
            int length = resourceData.GetNumberOfResources();

            for (int i = 0; i < length; i++) {
                if (!resourceData.IsUnlockedResource(i)) {
                    continue;
                }

                resourceText[i].text = resourceData.GetResource(i).ToString();
            }
        }

        public void UpdateResource(int index) {
            resourceText[index].text = resourceData.GetResource(index).ToString();
        }

        private void CreateResourceText() {
            int length = resourceData.GetNumberOfResources();
            resourceText = new TextMeshProUGUI[length];

            for (int i = 0; i < length; i++) {
                if (!resourceData.IsUnlockedResource(i)) {
                    continue;
                }

                TextMeshProUGUI text = Instantiate(resourcePrefab, transform).GetComponent<TextMeshProUGUI>();
                text.text = resourceData.GetResource(i).ToString();
                resourceText[i] = text;
            }
        }
    }
}