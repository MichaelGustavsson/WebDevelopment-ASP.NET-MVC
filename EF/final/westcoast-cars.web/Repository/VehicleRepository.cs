using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Data;
using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Repository;

public class VehicleRepository : IVehicleRepository
{
    private readonly WestcoastCarsContext _context;
    public VehicleRepository(WestcoastCarsContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Vehicle vehicle)
    {
        try
        {
            await _context.Vehicles.AddAsync(vehicle);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> DeleteAsync(Vehicle vehicle)
    {
        try
        {
            _context.Vehicles.Remove(vehicle);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public async Task<Vehicle?> FindByIdAsync(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<Vehicle?> FindByRegistrationNumberAsync(string regNo)
    {
        return await _context.Vehicles.SingleOrDefaultAsync(c => c.RegistrationNumber.Trim().ToLower() == regNo.Trim().ToLower());
    }

    public async Task<IList<Vehicle>> ListAllAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            if (await _context.SaveChangesAsync() > 0) return true;
            return false;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> UpdateAsync(Vehicle vehicle)
    {
        try
        {
            _context.Vehicles.Update(vehicle);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}
