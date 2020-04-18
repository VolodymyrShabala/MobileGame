using TMPro;
using UnityEngine;

namespace Resources {
    public class ResourceVisual {
        private TextMeshProUGUI[] resourceText;
        private readonly ResourceManager resourceManager;
        private readonly TextMeshProUGUI resourcePrefab;
        private readonly Transform parent;

        public ResourceVisual(ResourceManager resourceManager, TextMeshProUGUI resourcePrefab, Transform parent) {
            UnityEngine.Assertions.Assert.IsNotNull(resourceManager, $"No resourceManager is assigned in ResourceVisual.");
            UnityEngine.Assertions.Assert.IsNotNull(resourcePrefab, $"No resourcePrefab is assigned in ResourceVisual.");
            UnityEngine.Assertions.Assert.IsNotNull(parent, $"No parent is assigned in ResourceVisual.");
            
            this.resourceManager = resourceManager;
            this.resourcePrefab = resourcePrefab;
            this.parent = parent;
            CreateResourceText();
        }

        private void CreateResourceText() {
            int length = resourceManager.ResourceAmount();
            resourceText = new TextMeshProUGUI[length];

            for (int i = 0; i < length; i++) {
                if (!resourceManager.IsUnlockedResource(i)) {
                    continue;
                }

                TextMeshProUGUI text = Object.Instantiate(resourcePrefab, parent);
                Resource resource = resourceManager.GetResource(i);
                text.text = resource.ToString();
                resourceText[i] = text;
                
                resource.onValuesChange += resourceText[i].SetText;
            }
        }
    }
}