namespace UserDataManagement.Database;
using Microsoft.Data.Sqlite;
using System.IO;
public static class DatabaseHelper
{
    private const string DatabaseFile = "UserData.db";
    private const string ConnectionString = $"Data Source={DatabaseFile}";

    public static void InitializeDatabase()
    {
        if (!File.Exists(DatabaseFile))
        {
            CreateDatabase();
        }
    }

    private static void CreateDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL
                )";

        string createDataEntriesTable = @"
                CREATE TABLE IF NOT EXISTS DataEntries (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT
                )";

        using var command = connection.CreateCommand();
        command.CommandText = createUsersTable;
        command.ExecuteNonQuery();

        command.CommandText = createDataEntriesTable;
        command.ExecuteNonQuery();
    }

    public static SqliteConnection GetConnection() => new SqliteConnection(ConnectionString);
}