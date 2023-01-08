using westcoast_cars.web.Models;

namespace westcoast_cars.web.Interfaces;
public interface IVehicleRepository : IRepository<VehicleModel>
{
    Task<VehicleModel?> FindByRegistrationNumberAsync(string regNo);
}
