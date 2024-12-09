namespace Database.Models;

public class OrderGetResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public List<OrderGetResponse> Orders { get; set; }
}