using Resources;
using UnityEditor;
using UnityEngine;

namespace Editor.DefaultGameDataWindow.ResourceWindow {
    public class ResourceEditorWindow {
        private string name;
        private float storageMax;
        private bool unlocked;
        public bool remove;

        public ResourceEditorWindow(Resource resource) {
            name = resource.GetName();
            storageMax = resource.GetStorageMax();
            unlocked = resource.IsUnlocked();
        }

        public void Show() {
            GUILayout.BeginHorizontal();
            name = EditorGUILayout.TextField("Name", name);

            if (GUILayout.Button("Remove")) {
                remove = true;
            }

            GUILayout.EndHorizontal();

            storageMax = EditorGUILayout.FloatField("Max storage", storageMax);
            unlocked = EditorGUILayout.Toggle("Unlocked", unlocked);
            GUILayout.Space(10);
        }

        public Resource GetResource() {
            return new Resource(name, 0, storageMax, 0, unlocked);
        }
    }
}