namespace Database.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Book> Books { get; set; }
    public Customer? Customer { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        Books = new List<Book>();
    }
    public Order(Customer customer, List<Book> books)
    {
        Customer = customer;
        Books = new List<Book>(books);
        Date = DateTime.Now;
        Id = Guid.NewGuid();
    }
}