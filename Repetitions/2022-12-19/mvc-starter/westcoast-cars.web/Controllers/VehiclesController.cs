using Microsoft.AspNetCore.Mvc;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Controllers
{
    // Attribut baserad routing
    // url: https://localhost:7018/vehicles
    [Route("vehicles")]
    public class VehiclesController : Controller
    {
        // url: https://localhost:7018/vehicles/index
        [Route("index")]
        public IActionResult Index()
        {
            var vehicles = new List<Vehicle>{
                new Vehicle{VehicleId = 1, Make ="Volvo", Model="V90"},
                new Vehicle{VehicleId = 2, Make ="Ford", Model="Mustang MACH-E"}
            };

            return View("Index", vehicles);
        }

        // url: https://localhost:7018/vehicles/index/id
        [Route("index/{id}")]
        public IActionResult Index(int id)
        {
            return View("Index");
        }

        // url: https://localhost:7018/vehicles/listactivevehicles
        [Route("listactivevehicle")]
        public IActionResult ListActiveVehicles()
        {
            return View("ActiveVehicles");
        }

        // url: https://localhost:7018/vehicles/details/vehicleId
        [Route("details/{vehicleId}")]
        public IActionResult Details(int vehicleId)
        {
            // ViewData["vehicleId"] = vehicleId;
            // ViewBag.VehicleId = vehicleId;

            // Gå till databas och hämta bilen
            var vehicle = new Vehicle
            {
                VehicleId = 2,
                Make = "Ford",
                Model = "Mustang MACH-E"
            };

            return View("Details", vehicle);
        }
    }
}