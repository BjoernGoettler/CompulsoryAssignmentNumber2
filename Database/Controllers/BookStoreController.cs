using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers;

[ApiController]
[Route("[controller]")]
public class BookStoreController: ControllerBase
{
    private readonly BookstoreContext _context;
    private readonly BookstoreRepository _repository;

    public BookStoreController(BookstoreContext context)
    {
        _context = context;
        _repository = new BookstoreRepository(_context);
    }
    
    [HttpPost]
    public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
    {
        var result = await _repository.AddBook(book);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(Guid id)
        => Ok( await _repository.GetBook(id));
    
    [HttpPost]
    public async Task<ActionResult<Author>> AddAuthor([FromBody] string name)
    {
        var result = await _repository.AddAuthor(name);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthor(Guid id)
        => Ok( await _repository.GetAuthor(id));
    
    [HttpPost]
    public async Task<ActionResult<Customer>> AddCustomer([FromBody] string name)
        => Ok( await _repository.AddCustomer(name));
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        => Ok( await _repository.GetCustomer(id));
    
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] Customer customer, [FromBody] List<Book> books)
        => Ok( await _repository.CreateOrder(customer, books));
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(Guid id)
        => Ok( await _repository.GetOrder(id));
}