using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Buildings.BuildingButton {
    public class BuildingButtonHolder : MonoBehaviour {
        public TextMeshProUGUI buildingNameAndAmount;
        public TextMeshProUGUI buildingDescription;
        public Transform buildingCostParent;
        public Transform buildingEffectParent;
        public Button[] buildButtons;
        public TextMeshProUGUI defaultTextPrefab;

        [Header("For collapsing")]
        public Button collapsibleButton;
        public GameObject body;

        private bool initialized;

        public void Init() {
            AssertButtonIsReady();
            initialized = true;
        
            collapsibleButton.onClick.AddListener(SwitchBodyVisibility);
            SwitchBodyVisibility();
        }

        private void SwitchBodyVisibility() {
            body.SetActive(!body.activeInHierarchy);
        }

        private void AssertButtonIsReady() {
            Assert.IsNotNull(buildingNameAndAmount, $"buildingNameAndAmount isn't assigned in {name}.");
            Assert.IsNotNull(buildingDescription, $"buildingDescription isn't assigned in {name}.");
            Assert.IsNotNull(buildingCostParent, $"buildingCostParent isn't assigned in {name}.");
            Assert.IsNotNull(buildingEffectParent, $"buildingEffectParent isn't assigned in {name}.");
            Assert.IsFalse(buildButtons.Length == 0, $"buildButtons aren't assigned in {name}.");
            Assert.IsNotNull(defaultTextPrefab, $"defaultTextPrefab isn't assigned in {name}.");
            Assert.IsNotNull(collapsibleButton, $"collapsibleButton isn't assigned in {name}.");
            Assert.IsNotNull(body, $"body isn't assigned in {name}.");
            Assert.IsFalse(initialized, $"Trying to initialize button when it is already initialized in {name}");
        }
    }
}