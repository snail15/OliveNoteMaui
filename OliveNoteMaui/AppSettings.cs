using SQLite;

namespace OliveNoteMaui;

public static class AppSettings
{
    private const string DB_FILE_NAME = "OliveNote.db3";
    
    public const SQLiteOpenFlags FLAGS = 
        SQLiteOpenFlags.ReadWrite | 
        SQLiteOpenFlags.Create | 
        SQLiteOpenFlags.SharedCache;

    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DB_FILE_NAME);
}
