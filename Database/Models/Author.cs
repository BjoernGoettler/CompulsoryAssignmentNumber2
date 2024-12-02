using Database.Interfaces;

namespace Database.Models;

public class Author: IPerson
{
    public string Name { get; set; }
    public Guid Id { get;}
    
    public Author(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    
}