using MongoDB.Bson;
using Database.Models;
using Database.Clients;

namespace Database.Repositories;

public class OrderRepository
{
    private readonly MyMongoClient _client;
    private readonly string _databaseName;
    private readonly string _collectionName;

    public OrderRepository(MyMongoClient client, string databaseName, string collectionName)
    {
        _client = client;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        var collection = _client.GetCollection<Order>(_databaseName, _collectionName);
        await collection.InsertOneAsync(order);
        return order;
    }
}