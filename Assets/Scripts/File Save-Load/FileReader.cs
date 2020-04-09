using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class FileReader {
    private static string defaultGameSaveFile = "/DefaultGameSave.txt";
    private static string gameSaveFile = "/GameSave.txt";


    public static void SaveGame(GameSave gameSave) {
        string filepath = Application.persistentDataPath + gameSaveFile;

        if (File.Exists(filepath)) {
            File.Delete(filepath);
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(filepath);

        try {
            binaryFormatter.Serialize(fileStream, gameSave);
        } catch (Exception exception) {
            Debug.LogError($"Failed to save data to {filepath}. Reason: {exception.Message}.");
            throw;
        } finally {
            fileStream.Dispose();
        }
    }

    public static GameSave LoadGame() {
        string filepath = Application.persistentDataPath + "/GameSave.txt";
        GameSave gameSave;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;

        try {
            fileStream = File.Open(filepath, FileMode.Open);
        } catch (Exception exception) {
            Debug.Log($"Couldn't open file at {filepath}. Reason: {exception.Message}.");
            return null;
        }

        try {
            gameSave = (GameSave) binaryFormatter.Deserialize(fileStream);
        } catch (Exception exception) {
            Debug.LogError($"Failed to load data from {filepath}. Reason: {exception.Message}.");
            throw;
        }

        fileStream.Dispose();

        return gameSave;
    }
    
    public static void SaveDefaultGame(GameSave gameSave) {
        string filepath = Application.dataPath + defaultGameSaveFile;
        if (File.Exists(filepath)) {
            File.Delete(filepath);
        }

        string saveData = "";

        try {
            saveData = JsonUtility.ToJson(gameSave);
        } catch (Exception exception) {
            Debug.Log($"Couldn't serialize GameSave to Json. Reason {exception.Message}.");
            throw;
        }

        try {
            File.WriteAllText(filepath, saveData);
        } catch (Exception exception) {
            Debug.Log($"Couldn't save game to a file. Reason {exception.Message}.");
            throw;
        }
    }

    public static GameSave LoadDefaultGame() {
        string filepath = Application.dataPath + defaultGameSaveFile;
        
        if (!File.Exists(filepath)) {
            File.Create(filepath);
            return null;
        }

        string content = File.ReadAllText(filepath);
        GameSave gameSave;

        try {
            gameSave = JsonUtility.FromJson<GameSave>(content);
        } catch (Exception exception) {
            Debug.Log($"Couldn't parse GameSave at {filepath}. Reason: {exception.Message}.");
            throw;
        }

        return gameSave;
    }
}