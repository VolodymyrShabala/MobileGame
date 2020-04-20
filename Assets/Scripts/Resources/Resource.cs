using System;

namespace Resources {
    public struct Resource {
        private string name;
        private float currentAmount;
        private float storageMax;
        private float gainPerSecond;
        private bool unlocked;

        // TODO: Add consumption info
        // TODO: Add What buildings buffs production and opposite

        public Resource(string name, float currentAmount = 0, float storageMax = 0, float gainPerSecond = 0,
                        bool unlocked = false) {
            this.name = name;
            this.currentAmount = currentAmount;
            this.storageMax = storageMax;
            this.gainPerSecond = gainPerSecond;
            this.unlocked = unlocked;
        }

        public void AddResources(float amount) {
            currentAmount += amount;
        }

        public void RemoveResources(float amount) {
            currentAmount -= amount;
        }

        public void IncreaseStorage(float amount) {
            storageMax += amount;
        }

        public void DecreaseStorage(float amount) {
            storageMax -= amount;
        }

        public void IncreaseGainPerSecond(float amount) {
            gainPerSecond += amount;
        }

        public void DecreaseGainPerSecond(float amount) {
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

        public float GetCurrentAmount() {
            return currentAmount;
        }

        public float GetStorageMax() {
            return storageMax;
        }

        public float GetGainPerSecond() {
            return gainPerSecond;
        }

        public bool IsStorageFull() {
            return Math.Abs(currentAmount - storageMax) < 0.001f;
        }

        public bool IsUnlocked() {
            return unlocked;
        }

        // TODO: Fix decimals
        public override string ToString() {
            return $"{name}:{currentAmount:F1}/{storageMax:0}({gainPerSecond:F1})";
        }
    }
}