﻿using System.IO;
using Buildings;
using NUnit.Framework;
using Resources;
using UnityEngine;

namespace Editor.Tests.EditMode.TestFileReader {
    public class TestFileReader {
        /*
         *Lägg till det förväntade resultatet i funktionens namn. I mitt team så använder vi oss utav följande testnamn
         *[KlassNamn]_ [VadTestas]_ [Resultat]
         *Så t.ex.
         *TestFileReader_CreateSaveFile_FileIsCreated
         *Ha inte för många Asserts i ett och samma test. Tests kommer sluta köra när den första Asserten är false,
         * vilket gör att du eventuellt gömmer fel som aldrig testades. Ha heldre många små test istället.
         *Dela upp test i Setup phase, execute phase, assert phase, för lättare overview
         */

        // [Test, Description("Testing saving GameSave"), Order(0)]
        // public void TestGameSave() {
        //     Resource[] resources = new Resource[1];
        //     resources[0] = new Resource(ResourceType.Food, 0, 10, 0, true);
        //     ResourceData resourceData = new ResourceData(resources);
        //     
        //     Building[] buildings = new Building[1];
        //     buildings[0] = new Building(BuildingType.Farm, "Farm", new BuildingCost[0], 0, new BuildingEffect[0], true);
        //     BuildingData buildingData = new BuildingData(buildings);
        //     
        //     GameSave gameSave = new GameSave(resourceData, buildingData);
        //     FileReader.SaveGame(gameSave);
        //     Assert.True(File.Exists(Application.persistentDataPath + "/GameSave.txt"));
        //     Assert.IsNotEmpty(File.ReadAllText(Application.persistentDataPath + "/GameSave.txt"));
        // }
        //
        // [Test, Description("Testing loading GameSave"), Order(1)]
        // public void TestGameLoad() {
        //     GameSave gameSave = FileReader.LoadGame();
        //     Assert.NotNull(gameSave);
        // }
        //
        // [Test, Description("Testing SaveResources function"), Order(0)]
        // public void TestSaveResources() {
        //     Resource[] resources = new Resource[1];
        //     resources[0] = new Resource(ResourceType.Food, 0, 10, 0, true);
        //     ResourceData resourceData = new ResourceData(resources);
        //     FileReader.SaveData(FileType.Resources, resourceData);
        //
        //     Assert.True(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Resources))));
        // }
        //
        // [Test, Description("Testing SaveBuildings function"), Order(0)]
        // public void TestSaveBuildings() {
        //     Building[] buildings = new Building[1];
        //     buildings[0] = new Building(BuildingType.Farm, "Farm", new BuildingCost[0], 0, new BuildingEffect[0], true);
        //     BuildingData buildingData = new BuildingData(buildings);
        //     FileReader.SaveData(FileType.Buildings, buildingData);
        //     
        //     Assert.True(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Buildings))));
        // }
        //
        // [Test, Description("Testing LoadResources function"), Order(1)]
        // public void TestLoadResources() {
        //     ResourceData resourceData = (ResourceData) FileReader.LoadData(FileType.Resources);
        //     Assert.NotNull(resourceData);
        // }
        //
        // [Test, Description("Testing LoadBuildings function"), Order(1)]
        // public void TestLoadBuildings() {
        //     BuildingData buildingData = (BuildingData) FileReader.LoadData(FileType.Buildings);
        //     Assert.NotNull(buildingData);
        // }
        //
        // [Test, Description("Testing DeleteSaveFile function"), Order(2)]
        // public void TestDeleteSaveFile() {
        //     FileReader.DeleteSaveFile(FileReader.GetFilePath(FileReader.GetFileName(FileType.Resources)));
        //     Assert.False(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Resources))));
        // }
        //
        // [Test, Description("Testing DeleteBuildingFile function"), Order(2)]
        // public void TestDeleteBuildingFile() {
        //     FileReader.DeleteSaveFile(FileReader.GetFilePath(FileReader.GetFileName(FileType.Buildings)));
        //     Assert.False(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Buildings))));
        // }
    }
}