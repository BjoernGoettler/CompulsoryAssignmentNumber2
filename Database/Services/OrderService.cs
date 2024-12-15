using Database.Clients;
using Database.DbContexts;
using Database.Models;
using Database.Repositories;
using MongoDB.Bson;

namespace Database.Services;

public class OrderService
{
    private readonly MyMongoClient _client;
    private readonly string _databaseName;
    private readonly string _collectionName;
    private readonly OrderRepository _orderRepository;
    private readonly BookstoreRepository _bookstoreRepository;

    public OrderService(MyMongoClient client, BookstoreContext context)
    {
        _client = client;
        _databaseName = "orders";
        _collectionName = "orders";
        _orderRepository = new OrderRepository(client, _databaseName, _collectionName);
        _bookstoreRepository = new BookstoreRepository(context);
    }

    public async Task<OrderCreateResponse> CreateOrder(OrderCreateRequest request)
    {
        var customer = await _bookstoreRepository.GetCustomer(request.CustomerId);
        var order = new Order
        {
            Id = new ObjectId(),
            Books = new List<Book>(),
            Customer = customer,
            Date = DateTime.Now,
        };

        foreach (var book in request.BookIds)
        {
            order.Books.Add(await _bookstoreRepository.GetBook(book));
        }
        var orderResponse =  await _orderRepository.CreateOrder(order);

        return new OrderCreateResponse
        {
            Id = order.Id,
            Customer = new CustomerGetResponse
            {
                Id = orderResponse.Customer.Id,
                Name = orderResponse.Customer.Name,
            },
            Date = orderResponse.Date,
            Books = new BooksGetResponse(orderResponse.Books)
        };
    }
}