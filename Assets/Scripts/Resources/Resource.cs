using System;

namespace Resources {
    // TODO: Change to struct
    public struct Resource {
        private string name;
        private float storageAmount;
        private float storageMax;
        private float gainPerSecond;
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

        public void AddResources(float amount) {
            storageAmount += amount;
        }

        public void RemoveResources(float amount) {
            storageAmount -= amount;
        }

        public void AddStorage(float amount) {
            storageMax += amount;
        }

        public void RemoveStorage(float amount) {
            storageMax -= amount;
        }

        public void AddGainPerSecond(float amount) {
            gainPerSecond += amount;
        }

        public void RemoveGainPerSecond(float amount) {
            gainPerSecond -= amount;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public void SetUnlocked() {
            unlocked = true;
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

        public bool IsStorageFull() {
            return Math.Abs(storageAmount - storageMax) < 0.001f;
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