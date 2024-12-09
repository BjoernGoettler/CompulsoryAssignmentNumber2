namespace Database.Models;

public class CustomersGetResponse
{
    public List<CustomerGetResponse> Customers { get; set; }

    public CustomersGetResponse(List<Customer> customers)
    {
        Customers = new List<CustomerGetResponse>();
        foreach (var customer in customers)
        {
            Customers.Add(new CustomerGetResponse
            {
                Id = customer.Id,
                Name = customer.Name,
            });
        }
    }
}