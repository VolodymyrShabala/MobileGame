using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add removing from UpdateFunc
public class Tick : MonoBehaviour {
    [SerializeField] private float fps = 0.2f;
    private Action onUpdate;
    private float timer;

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

#region Singleton
    public static Tick instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }

        instance = this;
    }
#endregion
}