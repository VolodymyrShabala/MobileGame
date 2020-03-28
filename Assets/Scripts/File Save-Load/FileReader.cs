using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Resources;
using UnityEngine;

public static class FileReader {
    private static string fileFormat = ".txt";
    private static string resourcesFileName = "Resources";
    private static string buildingsFileName = "Buildings";

    public static ResourceData LoadResourceData() {
        string filePath = Application.persistentDataPath + "/" + GetFileName(FileName.Resources) + fileFormat;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;
        ResourceData resourceData;
        try {
            fileStream = File.Open(filePath, FileMode.Open);
        } catch (Exception exception) {
            Debug.LogError($"Couldn't open file at {filePath}. Reason: {exception.Message}.");
            throw;
        }
        
        try {
            resourceData = (ResourceData) binaryFormatter.Deserialize(fileStream);
        } catch (Exception exception) {
            Debug.LogError($"Failed to load resources from {filePath}. Reason: {exception.Message}.");
            throw;
        }
        
        fileStream.Dispose();
        
        return resourceData;
    }

    public static void SaveResourceData(ResourceData resourceData) {
        string filePath = Application.persistentDataPath + "/" + GetFileName(FileName.Resources) + fileFormat;
        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(filePath);

        try {
            binaryFormatter.Serialize(fileStream, resourceData);
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
            case FileName.Buildings:
                return buildingsFileName;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileName), fileName, null);
        }
    }
}

public enum FileName{ Resources, Buildings }