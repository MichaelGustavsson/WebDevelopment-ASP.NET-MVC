using Microsoft.AspNetCore.Mvc;
using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Models;
using westcoast_cars.web.ViewModels;

namespace westcoast_cars.web.Controllers
{
    [Route("vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _unitOfWork.VehicleRepository.ListAllAsync();
            return View("Index", vehicles);
        }

        [Route("details/{vehicleId}")]
        public async Task<IActionResult> Details(int vehicleId)
        {
            var vehicle = await _unitOfWork.VehicleRepository.FindByIdAsync(vehicleId);


            if (vehicle is not null)
            {
                var model = new VehicleViewModel
                {
                    VehicleId = vehicle.VehicleId,
                    Manufacturer = vehicle.Manufacturer,
                    Model = vehicle.Model,
                    ModelYear = vehicle.ModelYear,
                    Mileage = vehicle.Mileage,
                    Value = vehicle.Value,
                    ImageUrl = vehicle.ImageUrl,
                    Description = vehicle.Description
                };
                return View("Details", vehicle);
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta alla bilar",
            };

            return View("_Error", error);
        }
    }
}