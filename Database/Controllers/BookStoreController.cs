using Database.DbContexts;
using Database.Models;
using Database.Repositories;
using Database.Services;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookStoreController: ControllerBase
{
    private readonly BookstoreContext _context;
    private readonly BookstoreService _service;

    public BookStoreController(BookstoreContext context)
    {
        _context = context;
        _service = new BookstoreService(_context);
    }
    
    [HttpPost]
    [Route("book")]
    public async Task<ActionResult<BookCreateResponse>> CreateBook([FromBody] BookCreateRequest book)
    {
        var result = await _service.CreateBook(book);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("book/{id:guid}")]
    public async Task<ActionResult<BookGetResponse>> GetBook(Guid id)
        => Ok( await _service.GetBook(id));
    
    [HttpGet]
    [Route("books")]
    public async Task<ActionResult<BooksGetResponse>> GetBooks()
        => Ok( await _service.GetBooks());
    
    [HttpPost]
    [Route("author")]
    public async Task<ActionResult<AuthorCreateResponse>> AddAuthor([FromBody] AuthorCreateRequest author)
        => Ok(await _service.CreateAuthor(author));
    
    [HttpGet]
    [Route("author/{id:guid}")]
    public async Task<ActionResult<AuthorGetResponse>> GetAuthor(Guid id)
        => Ok( await _service.GetAuthor(id));
    
    [HttpGet]
    [Route("authors")]
    public async Task<ActionResult<List<Author>>> GetAuthors()
        => Ok(await _service.GetAuthors());
    
    [HttpPost]
    [Route("customer")]
    public async Task<ActionResult<Customer>> AddCustomer([FromBody]CustomerCreateRequest customer)
        => Ok( await _service.CreateCustomer(customer));
    
    [HttpGet]
    [Route("customer/{id:guid}")]
    public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        => Ok( await _service.GetCustomer(id));
    
    [HttpGet]
    [Route("customers")]
    public async Task<ActionResult<CustomersGetResponse>> GetCustomers()
        => Ok( await _service.GetCustomers());
    
}