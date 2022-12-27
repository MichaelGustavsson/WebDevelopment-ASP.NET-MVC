using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_cars.Data;
using westcoast_cars.Models;

namespace westcoast_cars.Controllers;

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
    public async Task<IActionResult> Details(int vehicleId)
    {
        var model = await _context.Vehicles.FirstOrDefaultAsync(c => c.Id == vehicleId);

        return View("Details", model);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var vehicle = new VehicleModel();
        return View("Create", vehicle);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(VehicleModel vehicleModel)
    {
        _context.Vehicles.Add(vehicleModel);
        if (await _context.SaveChangesAsync() > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            var vehicle = new VehicleModel();
            return View("Create", vehicle);
        }
    }
}
