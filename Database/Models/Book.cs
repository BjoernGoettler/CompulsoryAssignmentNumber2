namespace Database.Models;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required int Year { get; set; }
    public required Author Author { get; set; }

    public Book(string title, int year, Author author)
    {
        Title = title;
        Year = year;
        Id = Guid.NewGuid();
        Author = author;
    }
    
    public Book()
    {}
}