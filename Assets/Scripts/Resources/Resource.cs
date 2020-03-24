namespace Resources {
    [System.Serializable] // Added to be able to save in FileReader
    public struct Resource {
        public string name;
        public float amount;
        public float maxStorage;
        public float gainPerSecond; // TODO: Change name
    
        // TODO: Add consumption info
        // TODO: Add What buildings buffs production and opposite
        
        
        public Resource(string name, float amount, float maxStorage, float gainPerSecond) {
            this.name = name;
            this.amount = amount;
            this.maxStorage = maxStorage;
            this.gainPerSecond = gainPerSecond;
        }
    }
}