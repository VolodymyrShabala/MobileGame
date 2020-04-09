namespace Resources {
    [System.Serializable]
    public struct Resource {
        public string name;
        public float storedAmount;
        public float maxStorage;
        public float gainPerSecond;
        public bool unlocked;
        // TODO: Add consumption info
        // TODO: Add What buildings buffs production and opposite

        public Resource(string name, float storedAmount = 0, float maxStorage = 0, float gainPerSecond = 0,
                        bool unlocked = false) {
            this.name = name;
            this.storedAmount = storedAmount;
            this.maxStorage = maxStorage;
            this.gainPerSecond = gainPerSecond;
            this.unlocked = unlocked;
        }

        public void Update() {
            if (!unlocked) {
                return;
            }

            storedAmount += gainPerSecond;

            if (storedAmount >= maxStorage) {
                storedAmount = maxStorage;
            }
        }

        public override string ToString() {
            return $"{name}: {storedAmount}/{maxStorage}({gainPerSecond})";
        }
    }
}