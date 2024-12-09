using Database.DbContexts;
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
    
    public async Task<Book> CreateBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }
    
    public async Task<Book> GetBook(Guid id)
        => await _context.Books.FindAsync(id);
    
    public async Task<List<Book>> GetBooks()
        => await _context.Books.ToListAsync();
        //=> await _context.Books.Include(b => b.Author).ToListAsync();
    
    public async Task<Author> CreateAuthor(string name)
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
    
    public async Task<List<Author>> GetAuthors()
        => await _context.Authors.ToListAsync();

    public async Task<Customer> CreateCustomer(string name)
    {
        var customer = new Customer(name);
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    
    public async Task<Customer> GetCustomer(Guid id)
        => await _context.Customers.FindAsync(id);
    
    public async Task<List<Customer>> GetCustomers()
        => await _context.Customers.ToListAsync();
}