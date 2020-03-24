using TMPro;
using UnityEngine;

namespace Resources {
    public class ResourceVisual : MonoBehaviour {
        private ResourceManager resourceManager;
        [SerializeField] private GameObject resourcePrefab;
        private TextMeshProUGUI[] resourceText;
        private Resource[] resources;

        public void Init(Resource[] resources) {
            this.resources = resources;
            int length = resources.Length;
            resourceText = new TextMeshProUGUI[length];
            for (int i = 0; i < length; i++) {
                TextMeshProUGUI text = Instantiate(resourcePrefab, transform).GetComponent<TextMeshProUGUI>();
                Resource resource = resources[i];

                text.text = $"{resource.name}: {resource.amount}/{resource.maxStorage}({resource.gainPerSecond})";
                resourceText[i] = text;
            }
        }
    }
}