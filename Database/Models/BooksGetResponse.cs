namespace Database.Models;

public class BooksGetResponse
{
    public List<BookGetResponse> Books { get; set; }

    public BooksGetResponse(ICollection<Book> books)
    {
        Books = new List<BookGetResponse>();

        foreach (var book in books)
        {
            Books.Add(new BookGetResponse(book));
        }
    }
    
    public BooksGetResponse()
    {}
}