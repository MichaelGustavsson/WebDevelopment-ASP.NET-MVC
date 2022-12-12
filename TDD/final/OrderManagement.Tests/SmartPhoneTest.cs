using OrderManagement.Domain;
namespace OrderManagement.Tests;

public class SmartPhoneTest
{
    [Fact]
    public void SmartPhone_ShouldHaveManufacturerName()
    {
        // Arrange
        var phone = new SmartPhone();

        // Act
        phone.Manufacturer = "Samsung";

        // Assert
        Assert.Equal("Samsung", phone.Manufacturer);
    }

    [Fact]
    public void SmartPhone_ShouldHaveFullName()
    {
        // Arrange...
        var phone = new SmartPhone();

        // Act...
        phone.Manufacturer = "Apple";
        phone.Model = "iPhone 13 Pro";

        // Assert...
        Assert.Equal("Apple iPhone 13 Pro", phone.FullName);
    }

    [Fact]
    public void SmartPhone_ShouldHaveManufacturerNameStartWithManufacturerName()
    {
        // Arrange...
        var phone = new SmartPhone();

        // Act...
        phone.Manufacturer = "Apple";
        phone.Model = "iPhone 13 Pro";

        // Assert...
        Assert.StartsWith("Apple", phone.FullName, StringComparison.InvariantCultureIgnoreCase);
    }

    [Fact]
    public void SmartPhone_FullNameShouldContain()
    {
        // Arrange...
        var phone = new SmartPhone();

        // Act...
        phone.Manufacturer = "Apple";
        phone.Model = "iPhone 13 Pro";

        // Assert...
        Assert.Contains("ple iP", phone.FullName, StringComparison.InvariantCultureIgnoreCase);
    }

    [Fact]
    public void SaveSmartPhone_WhenValidateIsInvalid_ShouldGenerateArgumentException()
    {
        // Arrange
        var phone = new SmartPhone();
        // Act
        phone.Manufacturer = " ";
        Action action = () => phone.Save();
        // Assert
        var ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Tillverkare saknas (Parameter 'Manufacturer')", ex.Message);
    }

    [Fact]
    public void SmartPhone_ShouldBeApple()
    {
        // Arrange
        var phone = new SmartPhone();

        // Act & Assert
        Assert.Contains("Apple", phone.Manufacturers);
    }

    [Fact]
    public void SmartPhone_ShouldNotBeLG()
    {
        // Arrange
        var phone = new SmartPhone();

        // Act & Assert
        Assert.DoesNotContain("LG", phone.Manufacturers);
    }

    [Fact]
    public void SmartPhone_ShouldBeOfTypeProduct()
    {
        // Arrange
        var phone = new SmartPhone();

        // Act & Assert
        Assert.IsAssignableFrom<Product>(phone);
    }
}