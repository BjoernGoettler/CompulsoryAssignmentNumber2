namespace Database.Models;

public class Book
{
    public string Title { get; set; }
    public List<Author> Authors { get; set; }
    public int Year { get; set; }
}