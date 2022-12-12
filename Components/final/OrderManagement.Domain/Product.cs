namespace OrderManagement.Domain;

public abstract class Product
{
    // Properties...
    public Guid ProductId { get; set; } = Guid.NewGuid();
    public string ItemNumber { get; set; } = "";
    public string? ProductName { get; set; }
    public Decimal Price { get; set; }
    public bool IsInStock { get; set; }
    public List<string> Manufacturers { get; set; } = new List<string>();

    // Protected Methods...
    protected abstract bool Validate();
    protected abstract void LoadManufacturers();
}