using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Data;
using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Models;
using westcoast_cars.web.ViewModels;

namespace westcoast_cars.web.Controllers;

[Route("vehicles/admin")]
public class VehiclesAdminController : Controller
{
    private readonly IVehicleRepository _repo;
    public IRepository<Vehicle> _genericRepo { get; }

    public VehiclesAdminController(IRepository<Vehicle> genericRepo, IVehicleRepository repo)
    {
        _genericRepo = genericRepo;
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var vehicles = await _genericRepo.ListAllAsync();

            var model = vehicles.Select(v => new VehicleListViewModel
            {
                VehicleId = v.VehicleId,
                RegistrationNumber = v.RegistrationNumber,
                Manufacturer = v.Manufacturer,
                Model = v.Model,
                ModelYear = v.ModelYear,
                Mileage = v.Mileage
            }).ToList();

            return View("Index", model);
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
        var vehicle = new VehiclePostViewModel();
        return View("Create", vehicle);

    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(VehiclePostViewModel vehicle)
    {
        try
        {
            if (!ModelState.IsValid) return View("Create", vehicle);

            var exists = await _repo.FindByRegistrationNumberAsync(vehicle.RegistrationNumber);

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när bilen skulle sparas!",
                    ErrorMessage = $"En bil med registreringsnummer {vehicle.RegistrationNumber} finns redan i systemet"
                };

                return View("_Error", error);
            }

            var vehicleToAdd = new Vehicle
            {
                RegistrationNumber = vehicle.RegistrationNumber,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                ModelYear = vehicle.ModelYear,
                Mileage = (int)vehicle.Mileage!
            };

            if (await _genericRepo.AddAsync(vehicleToAdd))
            {
                if (await _genericRepo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var saveError = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när bilen skulle sparas!",
                ErrorMessage = $"Det inträffade ett fel när bilen med registreringsnummer {vehicle.RegistrationNumber} skulle sparas"
            };

            return View("_Error", saveError);
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
            var result = await _genericRepo.FindByIdAsync(vehicleId);
            // if (vehicle is not null) return View("Edit", vehicle);
            if (result is null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när vi skulle hämta en bil för redigering",
                    ErrorMessage = $"Vi hittar ingen bil med id {vehicleId}"
                };

                return View("_Error", error);
            }

            var model = new VehicleUpdateViewModel
            {
                VehicleId = result.VehicleId,
                RegistrationNumber = result.RegistrationNumber,
                Manufacturer = result.Manufacturer,
                Model = result.Model,
                ModelYear = result.ModelYear,
                Mileage = result.Mileage
            };
            return View("Edit", model);
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
    public async Task<IActionResult> Edit(int vehicleId, VehicleUpdateViewModel vehicle)
    {
        try
        {
            if (!ModelState.IsValid) return View("Edit", vehicle);

            var vehicleToUpdate = await _genericRepo.FindByIdAsync(vehicleId);

            if (vehicleToUpdate is null) return RedirectToAction(nameof(Index));

            vehicleToUpdate.RegistrationNumber = vehicle.RegistrationNumber;
            vehicleToUpdate.Manufacturer = vehicle.Manufacturer;
            vehicleToUpdate.Model = vehicle.Model;
            vehicleToUpdate.ModelYear = vehicle.ModelYear;
            vehicleToUpdate.Mileage = (int)vehicle.Mileage!;

            if (await _genericRepo.UpdateAsync(vehicleToUpdate))
            {
                if (await _genericRepo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle spara bilen",
                ErrorMessage = $"Ett fel inträffade när vi skulle uppdatera bilen med registreringsnummer {vehicleToUpdate.RegistrationNumber}"
            };

            return View("_Error", error);
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
            var vehicleToDelete = await _genericRepo.FindByIdAsync(vehicleId);

            if (vehicleToDelete is null) return RedirectToAction(nameof(Index));

            if (await _genericRepo.DeleteAsync(vehicleToDelete))
            {
                if (await _genericRepo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när bilen skulle raderas",
                ErrorMessage = $"Ett fel inträffade när bilen med registeringsnummer {vehicleToDelete.RegistrationNumber} skulle tas bort"
            };

            return View("_Error", error);
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
