using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class FileReader {
    private static readonly string defaultGameSaveFile = "/DefaultGameSave.txt";
    private static readonly string gameSaveFile = "/GameSave.txt";

    public static void SaveGame(GameSave gameSave) {
        SaveGame(gameSave, Application.persistentDataPath + gameSaveFile);
    }

    public static GameSave LoadGame() {
        return LoadGame(Application.persistentDataPath + gameSaveFile);
    }

    public static void SaveDefaultGame(GameSave gameSave) {
        SaveGame(gameSave, Application.dataPath + defaultGameSaveFile);
    }

    public static GameSave LoadDefaultGame() {
        return LoadGame(Application.dataPath + defaultGameSaveFile);
    }

    private static void SaveGame(GameSave gameSave, string filepath) {
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

    private static GameSave LoadGame(string filepath) {
        if (!File.Exists(filepath)) {
            return null;
        }
        
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

    public static void DeleteSaveFile() {
        string filepath = Application.persistentDataPath + gameSaveFile;

        if (File.Exists(filepath)) {
            File.Delete(filepath);
        }
    }

    public static string GetSaveFilePath() {
        return Application.persistentDataPath + "/GameSave.txt";
    }
}