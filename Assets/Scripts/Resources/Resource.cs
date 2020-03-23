[System.Serializable] // Added to be able to save in FileReader
public struct Resource {
    public string name;
    public float amount;
    public float maxStorage;
    public float gainPerSecond; // TODO: Change name
    
    // TODO: Add consumption info
    // What buildings buffs production and opposite
}