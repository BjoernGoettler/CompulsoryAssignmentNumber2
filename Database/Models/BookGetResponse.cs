namespace Database.Models;

public class BookGetResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    
    public BookGetResponse(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        Year = book.Year;
        AuthorId = book.Author.Id;
        AuthorName = book.Author.Name;
    }
}