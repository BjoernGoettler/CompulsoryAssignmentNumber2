using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class BookstoreRepository
{
    private readonly BookstoreContext _context;
    public BookstoreRepository(BookstoreContext context)
    {
        _context = context;
    }
    
    public async Task<Book> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }
    
    public async Task<Book> GetBook(Guid id)
        => await _context.Books.FindAsync(id);
    
    public async Task<Author> AddAuthor(string name)
    {
        var author = new Author
        {
            Name = name
        };
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
    }
    
    public async Task<Author> GetAuthor(Guid id)
        => await _context.Authors.FindAsync(id);

    public async Task<Customer> AddCustomer(string name)
    {
        var customer = new Customer(name);
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    
    public async Task<Customer> GetCustomer(Guid id)
        => await _context.Customers.FindAsync(id);

    public async Task<Order> CreateOrder(Customer customer, List<Book> books)
    {
        var order = new Order(customer, books);
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
    
    public async Task<Order> GetOrder(Guid id)
        => await _context.Orders.FindAsync(id);
}