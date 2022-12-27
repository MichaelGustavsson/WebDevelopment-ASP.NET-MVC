using Microsoft.AspNetCore.Mvc;

namespace westcoast_cars.Controllers;

[Route("vehicles")]
public class VehiclesController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }

    [Route("details/{vehicleId}")]
    public IActionResult Details(int vehicleId)
    {
        return View("Index");
    }
}
