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
            resourceManager.onResourceUpdate += UpdateResourceText;
        }

        private void CreateResourceText(ResourceManager resourceManager, TextMeshProUGUI resourcePrefab,
                                        Transform parent) {
            int length = resourceManager.GetNumberOfResources();
            resourceText = new TextMeshProUGUI[length];

            for (int i = 0; i < length; i++) {
                resourceText[i] = Object.Instantiate(resourcePrefab, parent);
            }
        }

        //TODO: Resources are now showing after the first Update has been run
        private void UpdateResourceText(int resourceIndex, string text) {
            resourceText[resourceIndex].text = text;
        }
    }
}