namespace OrderManagement;

public class SmartPhone : Product, IProduct<SmartPhone>
{
    // Unique Properties for a SmartPhone...
    public string Manufacturer { get; set; } = "";
    public string Model { get; set; } = "";
    public string Size { get; set; } = "";
    public int Storage { get; set; }
    public string Color { get; set; } = "";
    public string FullName => $"{Manufacturer} {Model}";

    public SmartPhone()
    {
        LoadManufacturers();
    }

    public SmartPhone Find(Guid productId)
    {
        return new SmartPhone();
    }

    public List<SmartPhone> ListAll()
    {
        return new List<SmartPhone>();
    }

    public bool Save()
    {
        if (Validate()) { return true; }
        return false;
    }

    public override string ToString()
    {
        return $"Tillverkare: {Manufacturer}, Modell: {Model}, Skärmstorlek: {Size}, Lagring: {Storage} Color: {Color} Pris: {Price}";
    }

    protected override void LoadManufacturers()
    {
        Manufacturers = new List<string>{
            "Apple",
            "Samsung",
            "Sony",
            // "LG"
        };
    }

    protected override bool Validate()
    {
        if (string.IsNullOrEmpty(Manufacturer) || string.IsNullOrWhiteSpace(Manufacturer))
        {
            throw new ArgumentException("Tillverkare saknas", "Manufacturer");
        }

        return true;
    }
}