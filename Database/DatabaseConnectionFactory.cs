using DotNetEnv;
namespace Database;

public static class DatabaseConnectionFactory
{
    private readonly static string _database;
    private readonly static string _user;
    private readonly static string _password;
    private readonly static string _host = "127.0.0.1";
    
    static DatabaseConnectionFactory()
    {
        Env.Load();
        _database = Env.GetString("MYSQL_DATABASE") ?? "bookstore";
        _user = Env.GetString("MYSQL_USER") ?? "henning";
        _password = Env.GetString("MYSQL_PASSWORD") ?? "pressening";
    }
    
    public static string GetMySqlConnectionString()
    {
        return $"Server={_host};DatabaseOld={_database};Uid={_user};Pwd={_password};";
    }
}