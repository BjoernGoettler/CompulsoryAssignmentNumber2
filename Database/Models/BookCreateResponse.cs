namespace Database.Models;

public class BookCreateResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
}