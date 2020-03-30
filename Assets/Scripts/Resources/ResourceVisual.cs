﻿using TMPro;
using UnityEngine;

namespace Resources {
    public class ResourceVisual : MonoBehaviour {
        [SerializeField] private GameObject resourcePrefab;
        private TextMeshProUGUI[] resourceText;
        private ResourceData resourceData;

        public void Init(ResourceData resourceData) {
            this.resourceData = resourceData;
            int length = resourceData.GetNumberOfResources();
            resourceText = new TextMeshProUGUI[length];
            for (int i = 0; i < length; i++) {
                if (!resourceData.IsUnlockedResource(i)) {
                    continue;
                }
                
                TextMeshProUGUI text = Instantiate(resourcePrefab, transform).GetComponent<TextMeshProUGUI>();
                Resource resource = resourceData.GetResource(i);

                text.text = $"{resource.resourceType.ToString()}: {resource.amount}/{resource.maxStorage}({resource.gainPerSecond})";
                resourceText[i] = text;
            }
        }
    }
}