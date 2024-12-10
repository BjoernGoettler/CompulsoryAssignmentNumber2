using MongoDB.Driver;

namespace Database.Clients;

public class MongoClient
{
    private readonly string _connectionString;
    private IMongoClient _client;

    public MongoClient(string connectionString)
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