using westcoast_cars.web.Models;

namespace westcoast_cars.web.Interfaces;
public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<Vehicle?> FindByRegistrationNumberAsync(string regNo);
}
