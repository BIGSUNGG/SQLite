public class ConnectionString
{
    public static string DBPath { get; set; } = @"C:\Project\SQLite";

    static string GetConnectionString(string dbName)
    {
        return $@"Data Source={DBPath}{dbName}";
    }

    static public string GetSqliteConnectionString()
    {
        return GetConnectionString(@"\Sqlite.db");
    }
}
