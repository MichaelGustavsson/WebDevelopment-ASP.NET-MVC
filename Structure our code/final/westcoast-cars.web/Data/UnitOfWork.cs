using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Repository;

namespace westcoast_cars.web.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly WestcoastCarsContext _context;
    public UnitOfWork(WestcoastCarsContext context)
    {
        _context = context;
    }

    public IVehicleRepository VehicleRepository => new VehicleRepository(_context);
    public IUserRepository UserRepository => new UserRepository(_context);

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
