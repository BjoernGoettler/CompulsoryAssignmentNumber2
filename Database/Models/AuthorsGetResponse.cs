namespace Database.Models;

public class AuthorsGetResponse
{
    public List<AuthorGetResponse> Authors { get; set; }
    
    public AuthorsGetResponse(List<Author> authors)
    {
        Authors = new List<AuthorGetResponse>();
        foreach (var author in authors)
        {
            Authors.Add(new AuthorGetResponse
            {
                Id = author.Id,
                Name = author.Name,
            });
        }
    }
    
    public AuthorsGetResponse()
    {
        Authors = new List<AuthorGetResponse>();
    }
    
}