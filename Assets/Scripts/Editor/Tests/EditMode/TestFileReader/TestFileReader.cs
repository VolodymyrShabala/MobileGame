﻿using System.IO;
using Buildings;
using NUnit.Framework;
using Resources;

namespace Editor.Tests.EditMode.TestFileReader {
    public class TestFileReader {
        private GameSave gameSave;

        [SetUp]
        public void FileReader_SetUp() {
            ResourceManager resourceManager = new ResourceManager(new Resource[0]);
            BuildingManager buildingManager = new BuildingManager(new Building[0]);
            gameSave = new GameSave(resourceManager, buildingManager);
        }

        [Test]
        [Description("Testing saving game")]
        [Order(0)]
        public void FilReader_CreateSaveFile_FileIsCreated() {
            FileReader.SaveGame(gameSave);
            Assert.IsTrue(File.Exists(FileReader.GetSaveFilePath()));
        }

        [Test]
        [Description("Testing loading game")]
        [Order(1)]
        public void FileReader_ReadSaveFile_GameSaveIsNotNull() {
            Assert.NotNull(FileReader.LoadGame());
        }

        [Test]
        [Description("Testing deleting save file")]
        [Order(1)]
        public void FileReader_DeleteSaveFile_FileDeleted() {
            FileReader.DeleteSaveFile();
            Assert.IsFalse(File.Exists(FileReader.GetSaveFilePath()));
        }
    }
}