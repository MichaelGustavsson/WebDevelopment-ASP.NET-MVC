using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Data;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Controllers;

[Route("vehicles/admin")]
public class VehiclesAdminController : Controller
{
    private readonly WestcoastCarsContext _context;
    public VehiclesAdminController(WestcoastCarsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        return View("Index", vehicles);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var vehicle = new Vehicle();
        return View("Create", vehicle);

    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
