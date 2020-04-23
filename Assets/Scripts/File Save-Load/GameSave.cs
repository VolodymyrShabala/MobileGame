using System;
using Buildings;
using Resources;

[Serializable]
public class GameSave {
    public Resource[] resources;
    public Building[] buildings;
    
    public GameSave(Resource[] resources, Building[] buildings) {
        this.resources = resources;
        this.buildings = buildings;
    }
}