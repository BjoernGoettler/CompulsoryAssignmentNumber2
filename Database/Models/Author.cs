using Database.Interfaces;

namespace Database.Models;

public class Author: IPerson
{ 
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Book>? Books { get; set; }
 
    public Author(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    
    public Author()
    {
        Name = "";
        Id = Guid.NewGuid();
    }
}