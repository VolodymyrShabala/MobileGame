using Buildings;
using UnityEditor;
using UnityEngine;

namespace Editor.DefaultGameDataWindow.BuildingWindow {
    public class BuildingCostEditorWindow {
        private static int horizontalOffset = 20;

        private int resourceIndex;
        private float amount;

        public bool remove;

        public BuildingCostEditorWindow(BuildingCost buildingCost) {
            resourceIndex = buildingCost.resourceIndex;
            amount = buildingCost.amount;
        }

        public void Show() {
            GUILayout.BeginHorizontal();
            GUILayout.Space(horizontalOffset);

            resourceIndex = EditorGUILayout.Popup("Resource", resourceIndex, new[] {"", ""} /*GetResourceNames()*/);

            if (GUILayout.Button("Remove")) {
                remove = true;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(horizontalOffset);
            amount = EditorGUILayout.FloatField("Amount", amount);
            GUILayout.EndHorizontal();

            EditorGUILayout.Separator();
        }

        public BuildingCost GetBuildingCost() {
            return new BuildingCost(resourceIndex, amount);
        }
    }
}