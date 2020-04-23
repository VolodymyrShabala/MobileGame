using System.Collections.Generic;
using Buildings;
using Editor.DefaultGameDataWindow.BuildingWindow;
using Editor.DefaultGameDataWindow.ResourceWindow;
using Resources;
using UnityEditor;
using UnityEngine;

namespace Editor.DefaultGameDataWindow {
    public class DefaultGameDataWindow : EditorWindow {
        private static readonly List<ResourceEditorWindow> resourcesEditor = new List<ResourceEditorWindow>();
        private static readonly List<BuildingEditorWindow> buildingsEditor = new List<BuildingEditorWindow>();

        private Vector2 scrollPos;
        private bool viewResources, viewBuildings;

        [MenuItem("Window/Default Game Data")]
        private static void Init() {
            DefaultGameDataWindow window = (DefaultGameDataWindow) GetWindow(typeof(DefaultGameDataWindow));
            window.minSize = new Vector2(200, 300);
            InitializeWindowContent();
            window.Show();
        }

        private static void InitializeWindowContent() {
            GameSave gameSave = FileReader.LoadDefaultGame() ?? new GameSave(new Resource[0], new Building[0]);

            resourcesEditor.Clear();
            buildingsEditor.Clear();

            int length = gameSave.resources.Length;

            for (int i = 0; i < length; i++) {
                resourcesEditor.Add(new ResourceEditorWindow(gameSave.resources[i]));
            }

            length = gameSave.buildings.Length;

            for (int i = 0; i < length; i++) {
                buildingsEditor.Add(new BuildingEditorWindow(gameSave.buildings[i]));
            }
        }

        private void OnGUI() {
            GUI.skin.button.stretchWidth = false;
            GUI.skin.textField.stretchWidth = true;

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Resources")) {
                viewResources = true;
                viewBuildings = false;
            }

            if (GUILayout.Button("Buildings")) {
                viewBuildings = true;
                viewResources = false;
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Save")) {
                Save();
            }

            if (GUILayout.Button("Reload")) {
                InitializeWindowContent();
            }

            GUILayout.EndHorizontal();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            if (viewResources) {
                ShowResourcesContent();
            }

            if (viewBuildings) {
                ShowBuildingsContent();
            }

            EditorGUILayout.EndScrollView();
        }

        private void ShowResourcesContent() {
            int length = resourcesEditor.Count;

            for (int i = 0; i < length; i++) {
                resourcesEditor[i].Show();
            }

            for (int i = 0; i < length; i++) {
                if (resourcesEditor[i].remove) {
                    resourcesEditor.RemoveAt(i);
                }
            }

            if (GUILayout.Button("Create new resource")) {
                resourcesEditor.Add(new ResourceEditorWindow(new Resource("")));
            }
        }

        private void ShowBuildingsContent() {
            int length = buildingsEditor.Count;
            
            for (int i = 0; i < length; i++) {
               buildingsEditor[i].Show();
            }
            
            for (int i = 0; i < length; i++) {
                if (buildingsEditor[i].remove) {
                    buildingsEditor.RemoveAt(i);
                }
            }

            if (GUILayout.Button("Create new building")) {
                buildingsEditor.Add(new BuildingEditorWindow(new Building("", "", new BuildingCost[0],
                                                new BuildingEffect[0])));
            }
        }

        private void Save() {
            int length = resourcesEditor.Count;
            Resource[] resources = new Resource[length];

            for (int i = 0; i < length; i++) {
                resources[i] = resourcesEditor[i].GetResource();
            }
            
            length = buildingsEditor.Count;
            Building[] buildings = new Building[length];

            for (int i = 0; i < length; i++) {
                buildings[i] = buildingsEditor[i].GetBuilding();
            }

            GameSave gameSave = new GameSave(resources, buildings);
            FileReader.SaveDefaultGame(gameSave);
        }
    }
}