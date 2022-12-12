namespace OrderManagement.Domain;

public class Order
{
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public Decimal OrderValue { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public void AddOrderItem(OrderItem item)
    {
        OrderItems.Add(item);
    }

    public bool Save()
    {
        if (!Validate())
        {
            throw new Exception("Det saknas information för att kunna spara beställningen");
        }

        OrderValue = OrderItems.Sum(c => c.Price);

        return true;
    }

    public Order Find(string orderId)
    {
        return new Order();
    }

    public List<Order> ListAll()
    {
        return new List<Order>();
    }

    private bool Validate()
    {
        var isValid = true;

        if (Customer is null)
        {
            isValid = false;
        }
        if (OrderItems is null || OrderItems.Count == 0)
        {
            isValid = false;
        }
        return isValid;
    }
}