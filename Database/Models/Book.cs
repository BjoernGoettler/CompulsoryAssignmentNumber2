namespace Database.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    

    public Book(string title, int year)
    {
        Title = title;
        Year = year;
        Id = Guid.NewGuid();
    }
    
}