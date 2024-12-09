using System.Runtime.InteropServices.JavaScript;

namespace Database.Models;

public class BookCreateRequest
{
    public string Title { get; set; }
    public int Year { get; set; }
    public Guid AuthorId { get; set; }
}