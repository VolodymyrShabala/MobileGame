public static class DataLoader {
    public static GameSave LoadOrCreateGame() {
        return FileReader.LoadGame() ?? FileReader.LoadDefaultGame();
    }
}