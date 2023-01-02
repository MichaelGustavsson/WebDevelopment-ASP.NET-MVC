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
        try
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return View("Index", vehicles);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta alla bilar",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
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
        try
        {
            var exists = await _context.Vehicles.SingleOrDefaultAsync(
            c => c.RegistrationNumber.Trim().ToLower() == vehicle.RegistrationNumber.Trim().ToLower());

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när bilen skulle sparas!",
                    ErrorMessage = $"En bil med registreringsnummer {vehicle.RegistrationNumber} finns redan i systemet"
                };

                return View("_Error", error);
            }

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle spara bilen",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [HttpGet("edit/{vehicleId}")]
    public async Task<IActionResult> Edit(int vehicleId)
    {
        try
        {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(c => c.VehicleId == vehicleId);

            if (vehicle is not null) return View("Edit", vehicle);

            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta en bil för redigering",
                ErrorMessage = $"Vi hittar ingen bil med id {vehicleId}"
            };

            return View("_Error", error);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi hämta bil för redigering",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [HttpPost("edit/{vehicleId}")]
    public async Task<IActionResult> Edit(int vehicleId, Vehicle vehicle)
    {
        try
        {
            var vehicleToUpdate = await _context.Vehicles.SingleOrDefaultAsync(c => c.VehicleId == vehicleId);

            if (vehicleToUpdate is null) return RedirectToAction(nameof(Index));

            vehicleToUpdate.RegistrationNumber = vehicle.RegistrationNumber;
            vehicleToUpdate.Manufacturer = vehicle.Manufacturer;
            vehicleToUpdate.Model = vehicle.Model;
            vehicleToUpdate.ModelYear = vehicle.ModelYear;
            vehicleToUpdate.Mileage = vehicle.Mileage;

            _context.Vehicles.Update(vehicleToUpdate);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle spara bilen",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [Route("delete/{vehicleId}")]
    public async Task<IActionResult> Delete(int vehicleId)
    {
        try
        {
            var vehicleToDelete = await _context.Vehicles.SingleOrDefaultAsync(c => c.VehicleId == vehicleId);

            if (vehicleToDelete is null) return RedirectToAction(nameof(Index));

            _context.Vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när bilen skulle raderas",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
}
