using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class FileReader {
    private static string fileFormat = ".txt";

    public static Resource[] LoadResources(string fileName) {
        string filePath = Application.persistentDataPath + "/" + fileName + fileFormat;
        if (!File.Exists(filePath)) {
            Debug.LogError($"No {filePath} file exist.");
            return default;
        }   
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;
        TempResourceSave temp;
        try {
            fileStream = File.Open(filePath, FileMode.Open);
        } catch (FileLoadException fileLoadException) {
            Debug.LogError($"Couldn't open file at {filePath}. Reason: {fileLoadException.Message}.");
            throw;
        }
        
        try {
            temp = (TempResourceSave) binaryFormatter.Deserialize(fileStream);
        } catch (SerializationException serializationException) {
            Debug.LogError($"Failed to load resources from {filePath}. Reason: {serializationException.Message}.");
            throw;
        }
        
        fileStream.Dispose();
        
        return temp.resources;
    }

    public static void SaveResources(Resource[] resources, string fileName) {
        string filePath = Application.persistentDataPath + "/" + fileName + fileFormat;
        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(filePath);
        TempResourceSave temp = new TempResourceSave {resources = resources};

        try {
            binaryFormatter.Serialize(fileStream, temp);
        } catch (SerializationException serializationException) {
            Debug.LogError($"Failed to save resources to {filePath}. Reason: {serializationException.Message}.");
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
}

[System.Serializable]
public struct TempResourceSave {
    public Resource[] resources;
}