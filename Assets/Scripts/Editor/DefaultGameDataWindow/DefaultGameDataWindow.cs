﻿using System.Collections.Generic;
using Buildings;
using Resources;
using UnityEditor;
using UnityEngine;

namespace Editor.DefaultGameDataWindow {
    public class DefaultGameDataWindow : EditorWindow {
        private static readonly List<Resource> resources = new List<Resource>();
        private static readonly List<Building> buildings = new List<Building>();

        private static readonly List<bool> foldOutBuildingCosts = new List<bool>();
        private static readonly List<bool> foldOutBuildingEffects = new List<bool>();
        private int foldOutHorizontalOffset = 20;
        private Vector2 scrollPos;
        private bool viewResources, viewBuildings;

        //[MenuItem("Window/Default Game Data")]
        //private static void Init() {
        //    DefaultGameDataWindow window = (DefaultGameDataWindow) GetWindow(typeof(DefaultGameDataWindow));
        //    window.minSize = new Vector2(200, 300);
        //    InitializeWindowContent();
        //    window.Show();
        //}
        //
        //private static void InitializeWindowContent() {
        //    GameSave gameSave = FileReader.LoadGame() ??
        //                        new GameSave(new ResourceData(new Resource[0]), new BuildingData(new Building[0]));
        //
        //    resources.Clear();
        //    buildings.Clear();
        //
        //    foldOutBuildingCosts.Clear();
        //    foldOutBuildingEffects.Clear();
        //
        //    int length = gameSave.resourceData.Length;
        //
        //    for (int i = 0; i < length; i++) {
        //        resources.Add(gameSave.resourceData.GetResource(i));
        //    }
        //
        //    length = gameSave.buildingData.Length;
        //
        //    for (int i = 0; i < length; i++) {
        //        buildings.Add(gameSave.buildingData.GetBuilding(i));
        //    }
        //
        //    foldOutBuildingCosts.AddRange(new bool[length]);
        //    foldOutBuildingEffects.AddRange(new bool[length]);
        //}
        //
        //private void OnGUI() {
        //    GUI.skin.button.stretchWidth = false;
        //    GUI.skin.textField.stretchWidth = true;
        //
        //    GUILayout.BeginHorizontal();
        //
        //    if (GUILayout.Button("Resources")) {
        //        viewResources = true;
        //        viewBuildings = false;
        //    }
        //
        //    if (GUILayout.Button("Buildings")) {
        //        viewBuildings = true;
        //        viewResources = false;
        //    }
        //
        //    GUILayout.Space(20);
        //
        //    if (GUILayout.Button("Save")) {
        //        Save();
        //    }
        //
        //    if (GUILayout.Button("Reload")) {
        //        InitializeWindowContent();
        //    }
        //
        //    GUILayout.EndHorizontal();
        //
        //    scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);
        //
        //    if (viewResources) {
        //        ShowResourcesContent();
        //    }
        //
        //    if (viewBuildings) {
        //        ShowBuildingsContent();
        //    }
        //
        //    EditorGUILayout.EndScrollView();
        //}
        //
        //private void ShowResourcesContent() {
        //    int length = resources.Count;
        //    int removeAt = -1;
        //
        //    for (int i = 0; i < length; i++) {
        //        GUILayout.BeginHorizontal();
        //        Resource resource = resources[i];
        //        resource.name = EditorGUILayout.TextField("Name", resource.name);
        //
        //        if (GUILayout.Button("Remove")) {
        //            removeAt = i;
        //        }
        //
        //        GUILayout.EndHorizontal();
        //
        //        resource.maxStorage = EditorGUILayout.FloatField("Max storage", resource.maxStorage);
        //        resource.unlocked = EditorGUILayout.Toggle("Unlocked", resource.unlocked);
        //
        //        resources[i] = resource;
        //
        //        GUILayout.Space(10);
        //    }
        //
        //    if (removeAt != -1) {
        //        resources.RemoveAt(removeAt);
        //    }
        //
        //    if (GUILayout.Button("Create new resource")) {
        //        resources.Add(new Resource(""));
        //    }
        //}
        //
        //private void ShowBuildingsContent() {
        //    int length = buildings.Count;
        //    int removeAt = -1;
        //
        //    for (int i = 0; i < length; i++) {
        //        GUILayout.BeginHorizontal();
        //
        //        Building building = buildings[i];
        //        building.name = EditorGUILayout.TextField("Name", building.name);
        //
        //        if (GUILayout.Button("Remove")) {
        //            removeAt = i;
        //        }
        //
        //        GUILayout.EndHorizontal();
        //
        //        building.description = EditorGUILayout.TextField("Description", building.description);
        //        foldOutBuildingCosts[i] = EditorGUILayout.Foldout(foldOutBuildingCosts[i], "Building costs");
        //
        //        if (foldOutBuildingCosts[i]) {
        //            ShowBuildingCosts(ref building);
        //        }
        //
        //        foldOutBuildingEffects[i] = EditorGUILayout.Foldout(foldOutBuildingEffects[i], "Building effects");
        //
        //        if (foldOutBuildingEffects[i]) {
        //            ShowBuildingEffects(ref building);
        //        }
        //
        //        building.unlocked = EditorGUILayout.Toggle("Unlocked", building.unlocked);
        //        buildings[i] = building;
        //
        //        GUILayout.Space(10);
        //    }
        //
        //    if (removeAt != -1) {
        //        buildings.RemoveAt(removeAt);
        //        foldOutBuildingCosts.RemoveAt(removeAt);
        //        foldOutBuildingEffects.RemoveAt(removeAt);
        //    }
        //
        //    if (GUILayout.Button("Create new building")) {
        //        buildings.Add(new Building("", "", new BuildingCost[0],
        //                                   new BuildingEffect[] {new IncreaseProduction(0, 1)}));
        //
        //        foldOutBuildingCosts.Add(false);
        //        foldOutBuildingEffects.Add(false);
        //    }
        //}
        //
        //private void ShowBuildingCosts(ref Building building) {
        //    int length = building.buildingCosts.Length;
        //    int removeAt = -1;
        //
        //    for (int i = 0; i < length; i++) {
        //        BuildingCost buildingCost = building.buildingCosts[i];
        //
        //        GUILayout.BeginHorizontal();
        //        GUILayout.Space(foldOutHorizontalOffset);
        //
        //        buildingCost.resourceIndex =
        //                EditorGUILayout.Popup("Resource", buildingCost.resourceIndex, GetResourceNames());
        //
        //        if (GUILayout.Button("Remove")) {
        //            removeAt = i;
        //        }
        //
        //        GUILayout.EndHorizontal();
        //
        //        GUILayout.BeginHorizontal();
        //        GUILayout.Space(foldOutHorizontalOffset);
        //        buildingCost.amount = EditorGUILayout.FloatField("Amount", buildingCost.amount);
        //        GUILayout.EndHorizontal();
        //
        //        EditorGUILayout.Separator();
        //
        //        building.buildingCosts[i] = buildingCost;
        //    }
        //
        //    if (removeAt != -1) {
        //        List<BuildingCost> buildingCosts = new List<BuildingCost>(building.buildingCosts);
        //        buildingCosts.RemoveAt(removeAt);
        //        building.buildingCosts = buildingCosts.ToArray();
        //    }
        //
        //    GUILayout.BeginHorizontal();
        //    GUILayout.Space(foldOutHorizontalOffset);
        //
        //    if (GUILayout.Button("Add building cost")) {
        //        List<BuildingCost> buildingCosts = new List<BuildingCost>(building.buildingCosts) {
        //                new BuildingCost(0, 0)
        //        };
        //
        //        building.buildingCosts = buildingCosts.ToArray();
        //    }
        //
        //    GUILayout.EndHorizontal();
        //}

        // private void ShowBuildingEffects(ref Building building) {
        // building.buildingEffects[0] = (BuildingEffect) EditorGUILayout.ObjectField("Building effect", 
        //                                building.buildingEffects[0], typeof(BuildingEffect), false);

        // int length = building.buildingEffects.Length;
        // int removeAt = -1;
        //
        // for (int i = 0; i < length; i++) {
        //     BuildingEffect buildingEffects = building.buildingEffects[i];
        //     GUILayout.BeginHorizontal();
        //     GUILayout.Space(foldOutHorizontalOffset);
        //
        //     buildingEffects.effectType =
        //             (BuildingEffectType) EditorGUILayout.EnumPopup("Effect", buildingEffects.effectType);
        //
        //     if (GUILayout.Button("Remove")) {
        //         removeAt = i;
        //     }
        //
        //     GUILayout.EndHorizontal();
        //
        //     GUILayout.BeginHorizontal();
        //     GUILayout.Space(foldOutHorizontalOffset);
        //
        //     buildingEffects.resourceIndex =
        //             EditorGUILayout.Popup("Resource", buildingEffects.resourceIndex, GetResourceNames());
        //
        //     GUILayout.EndHorizontal();
        //
        //     GUILayout.BeginHorizontal();
        //     GUILayout.Space(foldOutHorizontalOffset);
        //     buildingEffects.amount = EditorGUILayout.FloatField("Amount", buildingEffects.amount);
        //     GUILayout.EndHorizontal();
        //
        //     EditorGUILayout.Separator();
        //
        //     building.buildingEffects[i] = buildingEffects;
        // }
        //
        // if (removeAt != -1) {
        //     List<BuildingEffect> buildingEffects = new List<BuildingEffect>(building.buildingEffects);
        //     buildingEffects.RemoveAt(removeAt);
        //     building.buildingEffects = buildingEffects.ToArray();
        // }
        //
        // GUILayout.BeginHorizontal();
        // GUILayout.Space(foldOutHorizontalOffset);
        //
        // if (GUILayout.Button("Add building effect")) {
        //     List<BuildingEffect> buildingEffects = new List<BuildingEffect>(building.buildingEffects) {
        //             new BuildingEffect(BuildingEffectType.None, 0, 0)
        //     };
        //
        //     building.buildingEffects = buildingEffects.ToArray();
        // }
        //
        // GUILayout.EndHorizontal();
        // }

        // private string[] GetResourceNames() {
        //     int length = resources.Count;
        //     string[] resourceNames = new string[length];
        //
        //     for (int i = 0; i < length; i++) {
        //         resourceNames[i] = resources[i].name;
        //     }
        //
        //     return resourceNames;
        // }

        // private void Save() {
        // ResourceData resourceData = new ResourceData(resources.ToArray());
        // BuildingData buildingData = new BuildingData(buildings.ToArray());
        // GameSave gameSave = new GameSave(resourceData, buildingData);
        // FileReader.SaveGame(gameSave);
        // }
    }
}