using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class FileReader {
    private static string fileFormat = ".txt";
    private static string resourcesFileName = "Resources";
    private static string buildingsFileName = "Buildings";

    public static object LoadData(FileType fileType) {
        string filePath = Application.persistentDataPath + "/" + GetFileName(fileType) + fileFormat;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;
        object data;
        
        try {
            fileStream = File.Open(filePath, FileMode.Open);
        } catch (Exception exception) {
            Debug.Log($"Couldn't open file at {filePath}. Reason: {exception.Message}.");
            return null;
        }
        
        try {
            data = binaryFormatter.Deserialize(fileStream);
        } catch (Exception exception) {
            Debug.LogError($"Failed to load data from {filePath}. Reason: {exception.Message}.");
            throw;
        }
        
        fileStream.Dispose();
        
        return data;
    }

    public static void SaveData(FileType fileType, object data) {
        string filePath = Application.persistentDataPath + "/" + GetFileName(fileType) + fileFormat;
        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(filePath);

        try {
            binaryFormatter.Serialize(fileStream, data);
        } catch (Exception exception) {
            Debug.LogError($"Failed to save data to {filePath}. Reason: {exception.Message}.");
            throw;
        } finally {
            fileStream.Dispose();
        }
    }
  
    public static void DeleteSaveFile(string filePath) {
        File.Delete(filePath);
    }

    public static string GetFilePath(string fileName) {
        return Application.persistentDataPath + "/" + fileName + fileFormat;
    }

    public static string GetFileName(FileType fileType) {
        switch (fileType) {
            case FileType.Resources:
                return resourcesFileName;
            case FileType.Buildings:
                return buildingsFileName;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
        }
    }
}

public enum FileType{ Resources, Buildings }