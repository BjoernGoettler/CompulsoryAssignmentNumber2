using Database.DbContexts;
using Database.Models;
using Database.Repositories;

namespace Database.Services;

public class BookstoreService
{
    private readonly BookstoreRepository _repository;

    public BookstoreService(BookstoreContext context)
    {
        _repository = new BookstoreRepository(context);
    }

    public async Task<AuthorCreateResponse> CreateAuthor(AuthorCreateRequest request)
    {
        var author = await _repository.CreateAuthor(request.Name);
        return new AuthorCreateResponse {Id = author.Id, Name = author.Name};
    }
    
    public async Task<AuthorGetResponse> GetAuthor(Guid id)
        => new AuthorGetResponse(await _repository.GetAuthor(id)) ;
    
    public async Task<AuthorsGetResponse> GetAuthors()
        => new AuthorsGetResponse(await _repository.GetAuthors());

    public async Task<BookCreateResponse> CreateBook(BookCreateRequest request)
    {
        var author = await _repository.GetAuthor(request.AuthorId);
        var book = new Book
        {
            Title = request.Title,
            Author = author,
            Year = request.Year
        };
        
        await _repository.CreateBook(book);

        return new BookCreateResponse
        {
            Id = book.Id,
            Title = book.Title,
            Year = book.Year,
            AuthorId = author.Id,
            AuthorName = author.Name
        };
    }

    public async Task<BookGetResponse> GetBook(Guid id)
    {
        var book = await _repository.GetBook(id);
        return new BookGetResponse(book);
    }

    public async Task<CustomerCreateResponse> CreateCustomer(CustomerCreateRequest request)
    {
        var customer = await _repository.CreateCustomer(request.Name);
        return new CustomerCreateResponse {Id = customer.Id, Name = customer.Name};
    }
    
    public async Task<CustomerGetResponse> GetCustomer(Guid id)
    {
        var customer = await _repository.GetCustomer(id);
        return new CustomerGetResponse {Id = customer.Id, Name = customer.Name};
    }
    
    public async Task<CustomersGetResponse> GetCustomers()
        => new CustomersGetResponse(await _repository.GetCustomers());
    
    public async Task<BooksGetResponse> GetBooks()
    {
        var books = await _repository.GetBooks();
        return new BooksGetResponse(books);
    }
}