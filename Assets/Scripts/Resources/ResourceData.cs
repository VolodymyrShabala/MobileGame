namespace Resources {
    [System.Serializable]
    public readonly struct ResourceData {
        private readonly Resource[] resources; // TODO: Needs to be readonly. List?

        public ResourceData(Resource[] resources) {
            this.resources = resources;
        }

        public void Update() {
            int length = GetNumberOfResources();
            for (int i = 0; i < length; i++) {
                resources[i].Update();
            }
        }

        public void Add(int index, float amount) {
            resources[index].amount += amount;
        }

        public void Remove(int index, float amount) {
            resources[index].amount -= amount;
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

        public void UnlockResource(int index) {
            resources[index].unlocked = true;
        }

        public bool IsUnlockedResource(int index) {
            return resources[index].unlocked;
        }
        
        public int GetNumberOfResources() {
            return resources.Length;
        }

        public Resource GetResource(int index) {
            return resources[index];
        }

        public bool IsEnoughResource(int index, float amount) {
            return resources[index].amount >= amount;
        }
    }
}