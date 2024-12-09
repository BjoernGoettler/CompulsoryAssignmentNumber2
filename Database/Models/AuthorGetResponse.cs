namespace Database.Models;

public class AuthorGetResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public AuthorGetResponse()
    {}

    public AuthorGetResponse(Author author)
    {
        Id = author.Id;
        Name = author.Name;
    }
}