namespace westcoast_cars.web.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; } = Guid.NewGuid();
        public string RegistrationNumber { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public string Model { get; set; } = "";
        public int ModelYear { get; set; }
        public int Mileage { get; set; }
    }
}