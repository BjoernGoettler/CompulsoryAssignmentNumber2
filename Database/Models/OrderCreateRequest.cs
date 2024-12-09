namespace Database.Models;

public class OrderCreateRequest
{
    public Guid CustomerId { get; set; }
    public List<Guid>? BookIds { get; set; } = new List<Guid>();
}