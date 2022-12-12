namespace OrderManagement;

public class OrderItem
{
    public int Quantity { get; set; } = 1;
    public string? DiscountCode { get; set; }
    public Decimal Price { get; set; }
    public Product Product { get; set; }

    public OrderItem(Product product, int quantity, string? discountCode)
    {
        Product = product;
        Quantity = quantity;
        DiscountCode = discountCode ?? "";

        if (!Validate())
        {
            throw new Exception("Information saknas");
        }
        CalculatePrice();
    }

    private void CalculatePrice()
    {
        if (DiscountCode == "ABC123")
        {
            if (Product is not null)
            {
                Price = Product.Price * (1 - 0.15M);
            }
        }
    }
    private bool Validate()
    {
        var isValid = true;

        if (Quantity <= 0)
        {
            isValid = false;
        }
        return isValid;
    }

    public override string ToString()
    {
        return $"Antal: {Quantity}, Pris {Price}";
    }
}