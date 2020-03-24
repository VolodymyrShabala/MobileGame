using System.IO;
using NUnit.Framework;
using Resources;

namespace Editor.Tests.EditMode.TestFileReader {
    public class TestFileReader {
        private string fileName;

        [SetUp]
        public void Setup() {
            fileName = FileReader.GetFileName(FileName.Resources);
        }
        
        [Test, Description("Testing SaveResources function"), Order(0)]
        public void TestSaveResources() {
            Resource[] resources = new Resource[1];
            resources[0].amount = 10;
            resources[0].resourceType = ResourceType.Food;
            resources[0].maxStorage = 100;
            resources[0].gainPerSecond = 2;
            ResourceData resourceData = new ResourceData(resources);
            FileReader.SaveResourceData(resourceData);

            Assert.True(File.Exists(FileReader.GetFilePath(fileName)));
        }

        [Test, Description("Testing LoadResources function"), Order(1)]
        public void TestLoadResources() {
            ResourceData resourceData = FileReader.LoadResourceData();
            Assert.NotNull(resourceData);
        }

        [Test, Description("Testing DeleteSaveFile function"), Order(2)]
        public void TestDeleteSaveFile() {
            FileReader.DeleteSaveFile(fileName);
            Assert.False(File.Exists(FileReader.GetFilePath(fileName)));
        }
    }
}