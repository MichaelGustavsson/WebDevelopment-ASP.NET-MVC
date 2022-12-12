namespace OrderManagement;

public class Book : Product, IProduct<Book>
{
    // Unique Properties for a Book...
    public string ISBN { get; set; } = "";
    public string Title { get; set; } = "";
    public string Publisher { get; set; } = "";
    public string Author { get; set; } = "";
    public int Pages { get; set; }
    public bool HasHardCover { get; set; } = false;
    public string FullName => $"{Title} {Author}";

    public Book Find(Guid productId)
    {
        return new Book();
    }

    public List<Book> ListAll()
    {
        return new List<Book>();
    }

    public bool Save()
    {
        Console.WriteLine("Sparar book...");
        return true;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Titel: {Title}, Författare: {Author}, Förläggare: {Publisher}, Antal sidor: {Pages}, Pris: {Price}";
    }

    protected override void LoadManufacturers()
    {
        throw new NotImplementedException();
    }

    protected override bool Validate()
    {
        return true;
    }
}