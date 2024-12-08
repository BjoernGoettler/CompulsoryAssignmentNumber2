using Database.Interfaces;

namespace Database.Models;

public class Customer: IPerson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    public Customer(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Orders = new List<Order>();
    }
}