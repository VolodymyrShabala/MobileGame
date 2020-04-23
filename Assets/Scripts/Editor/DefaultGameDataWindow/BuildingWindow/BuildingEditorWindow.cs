using Buildings;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Editor.DefaultGameDataWindow.BuildingWindow {
    public class BuildingEditorWindow {
        private string name;
        private string description;
        private readonly List<BuildingCostEditorWindow> costs;
        private readonly List<BuildingEffectEditorWindow> effects;
        private bool unlocked;

        private bool foldOutCost;
        private bool foldOutEffect;
        public bool remove;

        public BuildingEditorWindow(Building building) {
            name = building.GetName();
            description = building.GetDescription();

            BuildingCost[] buildingCosts = building.GetCosts();
            int length = buildingCosts.Length;
            costs = new List<BuildingCostEditorWindow>();

            for (int i = 0; i < length; i++) {
                costs.Add(new BuildingCostEditorWindow(buildingCosts[i]));
            }

            BuildingEffect[] buildingEffects = building.GetEffects();
            length = buildingEffects.Length;
            effects = new List<BuildingEffectEditorWindow>();

            for (int i = 0; i < length; i++) {
                effects.Add(new BuildingEffectEditorWindow(buildingEffects[i]));
            }
            
            unlocked = building.IsUnlocked();
        }

        public void Show(string[] resourceNames) {
            GUILayout.BeginHorizontal();

            name = EditorGUILayout.TextField("Name", name);

            if (GUILayout.Button("Remove")) {
                remove = true;
            }

            GUILayout.EndHorizontal();

            description = EditorGUILayout.TextField("Description", description);
            foldOutCost = EditorGUILayout.Foldout(foldOutCost, "Building costs");

            if (foldOutCost) {
                ShowCosts(resourceNames);
            }

            foldOutEffect = EditorGUILayout.Foldout(foldOutEffect, "Building effects");

            if (foldOutEffect) {
                ShowEffects(resourceNames);
            }

            unlocked = EditorGUILayout.Toggle("Unlocked", unlocked);

            GUILayout.Space(10);
        }

        private void ShowCosts(string[] resourceNames) {
            int length = costs.Count;

            for (int i = 0; i < length; i++) {
                costs[i].Show(resourceNames);
            }

            if (GUILayout.Button("Add building cost")) {
                costs.Add(new BuildingCostEditorWindow(new BuildingCost()));
            }
            
            for (int i = 0; i < length; i++) {
                if (costs[i].remove) {
                    costs.RemoveAt(i);
                }
            }
        }
        
        private void ShowEffects(string[] resourceNames) {
            int length = effects.Count;

            for (int i = 0; i < length; i++) {
                effects[i].Show(resourceNames);
            }

            if (GUILayout.Button("Add building effect")) {
                effects.Add(new BuildingEffectEditorWindow(new BuildingEffect()));
            }
            
            for (int i = 0; i < length; i++) {
                if (effects[i].remove) {
                    effects.RemoveAt(i);
                }
            }
        }

        public Building GetBuilding() {
            int length = costs.Count;
            BuildingCost[] buildingCosts = new BuildingCost[length];

            for (int i = 0; i < length; i++) {
                buildingCosts[i] = costs[i].GetBuildingCost();
            }
            
            length = effects.Count;
            BuildingEffect[] buildingEffects = new BuildingEffect[length];

            for (int i = 0; i < length; i++) {
                buildingEffects[i] = effects[i].GetEffect();
            }
            
            return new Building(name, description, buildingCosts, buildingEffects, 0, true, unlocked);
        }
    }
}