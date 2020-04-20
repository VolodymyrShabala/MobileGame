using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Resources {
    public class ResourceVisual {
        private TextMeshProUGUI[] resourceText;

        public ResourceVisual(ResourceManager resourceManager, TextMeshProUGUI resourcePrefab, Transform parent) {
            Assert.IsNotNull(resourceManager, "No resourceManager is assigned in ResourceVisual.");
            Assert.IsNotNull(resourcePrefab, "No resourcePrefab is assigned in ResourceVisual.");
            Assert.IsNotNull(parent, "No parent is assigned in ResourceVisual.");

            CreateResourceText(resourceManager, resourcePrefab, parent);
        }

        private void CreateResourceText(ResourceManager resourceManager, TextMeshProUGUI resourcePrefab,
                                        Transform parent) {
            int length = resourceManager.GetResourceAmount();
            resourceText = new TextMeshProUGUI[length];

            for (int i = 0; i < length; i++) {
                TextMeshProUGUI text = Object.Instantiate(resourcePrefab, parent);
                Resource resource = resourceManager.GetResource(i);

                if (resource.IsUnlocked()) {
                    text.text = resource.ToString();
                }
                resourceText[i] = text;

                resource.onValuesChange += resourceText[i].SetText;
            }
        }
    }
}