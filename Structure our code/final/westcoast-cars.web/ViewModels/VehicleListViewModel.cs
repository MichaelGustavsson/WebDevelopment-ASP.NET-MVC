namespace westcoast_cars.web.ViewModels;

public class VehicleListViewModel
{
    public int VehicleId { get; set; }
    public string VinNumber { get; set; } = "";
    public string RegistrationNumber { get; set; } = "";
    public string Manufacturer { get; set; } = "";
    public string Model { get; set; } = "";
    public string ModelYear { get; set; } = "";
    public int Mileage { get; set; }
}
