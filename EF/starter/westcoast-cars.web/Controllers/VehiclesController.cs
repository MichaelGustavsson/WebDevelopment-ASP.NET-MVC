using Microsoft.AspNetCore.Mvc;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Controllers
{
    //http://localhost:3000/vehicles
    [Route("vehicles")]
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            var vehicles = new List<Vehicle>{
                new Vehicle{RegistrationNumber = "ABC123", Manufacturer = "Volvo", Model = "V90", ModelYear = 2018, Mileage = 75000},
                new Vehicle{RegistrationNumber = "DEF123", Manufacturer = "Ford", Model = "Mustang MACH-E", ModelYear = 2022, Mileage = 100},
                new Vehicle{RegistrationNumber = "GHI123", Manufacturer = "Kia", Model = "Ceed", ModelYear = 2015, Mileage = 112500},
                new Vehicle{RegistrationNumber = "JKL123", Manufacturer = "BMW", Model = "X3", ModelYear = 2019, Mileage = 45500},
            };

            return View("Index", vehicles);
        }

        // https://localhost:7141/vehicles/details/101
        [Route("details/{vehicleId}")]
        public IActionResult Details(Guid vehicleId)
        {
            // Vi kommer att gå till backend för att hämta rätt bil med vehicleId...
            var foundVehicle = new Vehicle
            {
                RegistrationNumber = "DEF123",
                Manufacturer = "Ford",
                Model = "Mustang MACH-E",
                ModelYear = 2022,
                Mileage = 100
            };

            return View("Details", foundVehicle);
        }
    }
}