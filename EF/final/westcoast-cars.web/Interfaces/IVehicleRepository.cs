using westcoast_cars.web.Models;

namespace westcoast_cars.web.Interfaces;
public interface IVehicleRepository
{
    Task<IList<Vehicle>> ListAllAsync();
    Task<Vehicle?> FindByIdAsync(int id);
    Task<Vehicle?> FindByRegistrationNumberAsync(string regNo);
    Task<bool> AddAsync(Vehicle vehicle);
    Task<bool> UpdateAsync(Vehicle vehicle);
    Task<bool> DeleteAsync(Vehicle vehicle);
    Task<bool> SaveAsync();
}
