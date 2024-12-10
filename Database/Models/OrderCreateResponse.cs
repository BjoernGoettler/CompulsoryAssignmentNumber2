using MongoDB.Bson;

namespace Database.Models;

public class OrderCreateResponse
{
    public ObjectId Id { get; set; }
    public CustomerGetResponse Customer { get; set; }
    public BooksGetResponse Books { get; set; }
    public DateTime Date { get; set; }
}