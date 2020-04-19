using System;

namespace Resources {
    public class Resource {
        private float gainPerSecond;
        private string name;

        public Action<string> onValuesChange;
        private float storageAmount;
        private float storageMax;
        private bool unlocked;

        // TODO: Add consumption info
        // TODO: Add What buildings buffs production and opposite

        public Resource(string name, float storageAmount = 0, float storageMax = 0, float gainPerSecond = 0,
                        bool unlocked = false) {
            this.name = name;
            this.storageAmount = storageAmount;
            this.storageMax = storageMax;
            this.gainPerSecond = gainPerSecond;
            this.unlocked = unlocked;
        }

        public void Update() {
            if (!unlocked) {
                return;
            }

            storageAmount += gainPerSecond;

            if (storageAmount >= storageMax) {
                storageAmount = storageMax;
            }

            onValuesChange?.Invoke(ToString());
        }

        public void AddResources(float amount) {
            storageAmount += amount;
            onValuesChange?.Invoke(ToString());
        }

        public void RemoveResources(float amount) {
            storageAmount -= amount;
            onValuesChange?.Invoke(ToString());
        }

        public void AddStorage(float amount) {
            storageMax += amount;
            onValuesChange?.Invoke(ToString());
        }

        public void RemoveStorage(float amount) {
            storageMax -= amount;
            onValuesChange?.Invoke(ToString());
        }

        public void AddGainPerSecond(float amount) {
            gainPerSecond += amount;
            onValuesChange?.Invoke(ToString());
        }

        public void RemoveGainPerSecond(float amount) {
            gainPerSecond -= amount;
            onValuesChange?.Invoke(ToString());
        }

        public void SetName(string name) {
            this.name = name;
        }

        public void SetUnlocked() {
            unlocked = true;
            onValuesChange?.Invoke(ToString());
        }

        public string GetName() {
            return name;
        }

        public float GetStorageAmount() {
            return storageAmount;
        }

        public float GetStorageMax() {
            return storageMax;
        }

        public float GetGainPerSecond() {
            return gainPerSecond;
        }

        public bool IsUnlocked() {
            return unlocked;
        }

        // TODO: Fix decimals
        public override string ToString() {
            return $"{name}:{storageAmount:F1}/{storageMax:0}({gainPerSecond:F1})";
        }
    }
}