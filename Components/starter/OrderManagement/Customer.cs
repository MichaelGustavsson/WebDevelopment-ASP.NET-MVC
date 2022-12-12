namespace OrderManagement;

public class Customer
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public string CustomerNumber { get => CustomerId.ToString().Replace("-", ""); }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public bool Save()
    {
        return true;
    }

    public Customer Find(string email)
    {
        Console.WriteLine("Söker efter kund på e-post adress");
        return new Customer
        {
            FirstName = "Michael",
            LastName = "Gustavsson",
            Email = "michael@gmail.com",
            Phone = "+46-76-234567",
            Address = "Gatan 1",
            PostalCode = "12345",
            City = "Staden"
        };
    }

    public List<Customer> ListAll()
    {
        Console.WriteLine("Listar alla kunder");
        return new List<Customer>();
    }

    private bool Validate()
    {
        return true;
    }
}