public class ConnectionString
{
    static string GetConnectionString(string dbName)
    {
        return $@"Data Source={Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}{dbName}";
    }

    static public string GetSqliteConnectionString()
    {
        return GetConnectionString(@"\Sqlite.db");
    }
}
