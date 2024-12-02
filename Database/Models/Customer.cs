using Database.Interfaces;

namespace Database.Models;

public class Customer: IPerson
{
    public string Name { get; set; }
    public Guid Id { get;}
    
    public Customer(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
}