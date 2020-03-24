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
            Resource[] resource = new Resource[1];
            resource[0].amount = 10;
            resource[0].name = "Food";
            resource[0].maxStorage = 100;
            resource[0].gainPerSecond = 2;
            FileReader.SaveResources(resource);

            Assert.True(File.Exists(FileReader.GetFilePath(fileName)));
        }

        [Test, Description("Testing LoadResources function"), Order(1)]
        public void TestLoadResources() {
            Resource[] resources = FileReader.LoadResources();
            Assert.NotNull(resources);
        }

        [Test, Description("Testing DeleteSaveFile function"), Order(2)]
        public void TestDeleteSaveFile() {
            FileReader.DeleteSaveFile(fileName);
            Assert.False(File.Exists(FileReader.GetFilePath(fileName)));
        }
    }
}