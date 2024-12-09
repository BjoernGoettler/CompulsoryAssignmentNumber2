using Database.Interfaces;

namespace Database.Models;

public class Customer: IPerson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Customer(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
}