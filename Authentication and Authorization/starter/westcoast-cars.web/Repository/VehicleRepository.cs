using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Data;
using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Repository;

public class VehicleRepository : Repository<VehicleModel>, IVehicleRepository
{
    // private readonly WestcoastCarsContext _context;
    public VehicleRepository(WestcoastCarsContext context) : base(context) { }

    public async Task<VehicleModel?> FindByRegistrationNumberAsync(string regNo)
    {
        return await _context.Vehicles.SingleOrDefaultAsync(c => c.RegistrationNumber.Trim().ToLower() == regNo.Trim().ToLower());
    }
}
