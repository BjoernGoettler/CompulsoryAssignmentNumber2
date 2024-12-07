namespace Database.Models;

public class Order
{
    public Guid Id { get;}
    public List<Book> Books { get; set; } = new List<Book>();
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public Order(Customer customer)
    {
        Customer = customer;
        Date = DateTime.Now;
        Id = Guid.NewGuid();
    }
}