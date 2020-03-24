using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Resources;
using UnityEngine;

// TODO: Add functions to save and load other type of resources like Buildings
// TODO: Remove TempResourceSave struct
public static class FileReader {
    private static string fileFormat = ".txt";
    private static string resourcesFileName = "Resources";

    public static Resource[] LoadResources() {
        string filePath = Application.persistentDataPath + "/" + resourcesFileName + fileFormat;
        if (!File.Exists(filePath)) {
            Debug.LogError($"No {filePath} file exist.");
            return default;
        }   
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;
        TempResourceSave temp;
        try {
            fileStream = File.Open(filePath, FileMode.Open);
        } catch (Exception exception) {
            Debug.LogError($"Couldn't open file at {filePath}. Reason: {exception.Message}.");
            throw;
        }
        
        try {
            temp = (TempResourceSave) binaryFormatter.Deserialize(fileStream);
        } catch (Exception exception) {
            Debug.LogError($"Failed to load resources from {filePath}. Reason: {exception.Message}.");
            throw;
        }
        
        fileStream.Dispose();
        
        return temp.resources;
    }

    public static void SaveResources(Resource[] resources) {
        string filePath = Application.persistentDataPath + "/" + resourcesFileName + fileFormat;
        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(filePath);
        TempResourceSave temp = new TempResourceSave {resources = resources};

        try {
            binaryFormatter.Serialize(fileStream, temp);
        } catch (Exception exception) {
            Debug.LogError($"Failed to save resources to {filePath}. Reason: {exception.Message}.");
            throw;
        } finally {
            fileStream.Dispose();
        }
    }

    public static void DeleteSaveFile(string fileName) {
        string filePath = Application.persistentDataPath + "/" + fileName + fileFormat;
        File.Delete(filePath);
    }

    public static string GetFilePath(string fileName) {
        return Application.persistentDataPath + "/" + fileName + fileFormat;
    }

    public static string GetFileName(FileName fileName) {
        switch (fileName) {
            case FileName.Resources:
                return resourcesFileName;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileName), fileName, null);
        }
    }
    
    [Serializable]
    private struct TempResourceSave {
        public Resource[] resources;
    }
}

public enum FileName{ Resources }