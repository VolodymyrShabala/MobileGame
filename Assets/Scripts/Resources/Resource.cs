namespace Resources {
    [System.Serializable] // Added to be able to save in FileReader
    public struct Resource {
        public ResourceType resourceType;
        public float amount;
        public float maxStorage;
        public float gainPerSecond; // TODO: Change name
    
        // TODO: Add consumption info
        // TODO: Add What buildings buffs production and opposite
        
        
        public Resource(ResourceType resourceType, float amount, float maxStorage, float gainPerSecond) {
            this.resourceType = resourceType;
            this.amount = amount;
            this.maxStorage = maxStorage;
            this.gainPerSecond = gainPerSecond;
        }
    }
}

public enum ResourceType { Food, Wood }