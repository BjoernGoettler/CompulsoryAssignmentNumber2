using MongoDB.Driver;

namespace Database.Clients;

public class MyMongoClient
{
    private readonly string _connectionString;
    private IMongoClient _client;

    public MyMongoClient(string connectionString)
    {
        _connectionString = connectionString;
        Connect();
    }
    public void Connect()
    {
        _client = new MongoDB.Driver.MongoClient(_connectionString);
    }

    public IMongoCollection<T>GetCollection<T>(string database, string collectionName)
    {
        return _client.GetDatabase(database).GetCollection<T>(collectionName);
    }
}