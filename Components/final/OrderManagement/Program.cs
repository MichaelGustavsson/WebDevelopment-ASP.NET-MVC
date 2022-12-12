using OrderManagement.Domain;
namespace OrderManagement;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var customer = new Customer();

            var book = new Book
            {
                ISBN = "9781484278680",
                Pages = 1640,
                Author = "Andrew Troelsen, Phil Japikse",
                HasHardCover = false,
                Publisher = "Apress",
                ProductName = "Pro C# 10 with .NET 6",
                Price = 445
            };

            var orderItem = new OrderItem(book, 1, "ABC123");

            var order = new Order();
            order.Customer = customer;
            order.AddOrderItem(orderItem);

            order.AddOrderItem(new OrderItem(new SmartPhone
            {
                ProductName = "IPhone 14",
                Price = 16495,
                Color = "Midnatt",
                Storage = 512,
                Size = "6.1-tumsskärm",
                Manufacturer = "Apple",
                Model = "Pro"
            }, 1, "ABC123"));

            Console.WriteLine("");
            Console.WriteLine("Produkter i kundkorg");
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (var item in order.OrderItems)
            {
                // Console.WriteLine("Produkt {0}, Pris {1}", item.Product!.ProductName, item.Price);
                Console.WriteLine("{0} - {1}", item.Product, item);
            }

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------------");

            if (order.Save())
            {
                Console.WriteLine("Beställningen är genomförd");
                Console.WriteLine("Total kostnad för beställningen: {0}", order.OrderValue);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
