namespace Resources {
    [System.Serializable]
    public struct ResourceData {
        [UnityEngine.SerializeField] private Resource[] resources;

        public ResourceData(Resource[] resources) {
            this.resources = resources;
        }

        public void Update() {
            int length = Length;

            for (int i = 0; i < length; i++) {
                resources[i].Update();
            }
        }

        public void Add(int index, float amount) {
            resources[index].storedAmount += amount;
        }

        public void Remove(int index, float amount) {
            resources[index].storedAmount -= amount;
        }

        public void IncreaseProduction(int index, float amount) {
            resources[index].gainPerSecond += amount;
        }

        public void DecreaseProduction(int index, float amount) {
            resources[index].gainPerSecond -= amount;
        }

        public void IncreaseStorage(int index, float amount) {
            resources[index].maxStorage += amount;
        }

        public void DecreaseStorage(int index, float amount) {
            resources[index].maxStorage -= amount;
        }

        public void Unlock(int index) {
            resources[index].unlocked = true;
        }

        public bool IsUnlocked(int index) {
            return resources[index].unlocked;
        }

        public int Length => resources.Length;

        public Resource GetResource(int index) {
            return resources[index];
        }

        public bool IsEnoughResource(int index, float amount) {
            return resources[index].storedAmount >= amount;
        }

        public bool IsInRange(int index) {
            return index >= 0 && index < Length;
        }
    }
}