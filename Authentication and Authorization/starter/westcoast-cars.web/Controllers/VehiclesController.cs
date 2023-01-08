using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Data;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Controllers
{
    [Route("vehicles")]
    public class VehiclesController : Controller
    {
        private readonly WestcoastCarsContext _context;
        public VehiclesController(WestcoastCarsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return View("Index", vehicles);
        }

        [Route("details/{vehicleId}")]
        public IActionResult Details(Guid vehicleId)
        {
            // Vi kommer att gå till backend för att hämta rätt bil med vehicleId...
            var foundVehicle = new Vehicle
            {
                RegistrationNumber = "DEF123",
                Manufacturer = "Ford",
                Model = "Mustang MACH-E",
                ModelYear = "2022",
                Mileage = 100
            };

            return View("Details", foundVehicle);
        }
    }
}