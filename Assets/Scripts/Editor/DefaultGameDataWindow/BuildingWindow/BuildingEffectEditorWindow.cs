using System.Collections.Generic;
using Buildings;
using UnityEditor;
using UnityEngine;

namespace Editor.DefaultGameDataWindow.BuildingWindow {
    public class BuildingEffectEditorWindow {
        private static int horizontalOffset = 20;

        private float amount;
        private int buildingIndex = -1;
        private int resourceIndex = -1;

        public bool remove;

        public BuildingEffectEditorWindow(BuildingEffect effect) {
        }

        public void Show(string[] resourceNames) {
            GUILayout.BeginHorizontal();
            GUILayout.Space(horizontalOffset);

            resourceIndex = EditorGUILayout.Popup("Resource", resourceIndex, resourceNames);

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

        public BuildingEffect GetEffect() {
            return new BuildingEffect();
        }
    }
}