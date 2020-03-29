using System.IO;
using Buildings;
using NUnit.Framework;
using Resources;
using UnityEngine;

namespace Editor.Tests.EditMode.TestFileReader {
    public class TestFileReader {
        [Test, Description("Testing SaveResources function"), Order(0)]
        public void TestSaveResources() {
            Resource[] resources = new Resource[1];
            resources[0] = new Resource(ResourceType.Food, 0, 10, 0);
            ResourceData resourceData = new ResourceData(resources);
            FileReader.SaveData(FileType.Resources, resourceData);

            Assert.True(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Resources))));
        }

        [Test, Description("Testing SaveBuildings function"), Order(0)]
        public void TestSaveBuildings() {
            Building[] buildings = new Building[1];
            buildings[0] = new Building(BuildingType.Farm, "Farm", new BuildingCost[0], 0, new BuildingEffect(), true);
            BuildingData buildingData = new BuildingData(buildings);
            FileReader.SaveData(FileType.Buildings, buildingData);
            
            Assert.True(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Buildings))));
        }

        [Test, Description("Testing LoadResources function"), Order(1)]
        public void TestLoadResources() {
            ResourceData resourceData = (ResourceData) FileReader.LoadData(FileType.Resources);
            Assert.NotNull(resourceData);
        }
        
        [Test, Description("Testing LoadBuildings function"), Order(1)]
        public void TestLoadBuildings() {
            BuildingData buildingData = (BuildingData) FileReader.LoadData(FileType.Buildings);
            Assert.NotNull(buildingData);
        }

        [Test, Description("Testing DeleteSaveFile function"), Order(2)]
        public void TestDeleteSaveFile() {
            FileReader.DeleteSaveFile(FileReader.GetFilePath(FileReader.GetFileName(FileType.Resources)));
            Assert.False(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Resources))));
        }
        
        [Test, Description("Testing DeleteBuildingFile function"), Order(2)]
        public void TestDeleteBuildingFile() {
            FileReader.DeleteSaveFile(FileReader.GetFilePath(FileReader.GetFileName(FileType.Buildings)));
            Assert.False(File.Exists(FileReader.GetFilePath(FileReader.GetFileName(FileType.Buildings))));
        }
    }
}