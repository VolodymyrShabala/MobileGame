using System;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour {
#region Singleton
    public static Tick instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }

        instance = this;
    }
#endregion

    private List<object> objectsToUpdate = new List<object>();
    [SerializeField] private float fps = 0.2f;
    private float timer = 0;
    private Action onUpdate;
    
    private void Update() {
        timer += Time.deltaTime;

        if (timer >= fps) {
            timer = 0;
            UpdateLoop();
        }
    }

    private void UpdateLoop() {
        onUpdate?.Invoke();
    }

    public void UpdateFunc(Action function) {
        onUpdate += function;
    }
}