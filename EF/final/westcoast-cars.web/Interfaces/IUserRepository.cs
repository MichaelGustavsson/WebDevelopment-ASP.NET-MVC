using westcoast_cars.web.Models;

namespace westcoast_cars.web.Interfaces;

public interface IUserRepository
{
    Task<IList<UserModel>> ListAllAsync();
    Task<UserModel?> FindByIdAsync(int id);
    Task<UserModel?> FindByEmailAsync(string email);
    Task<bool> AddAsync(UserModel user);
    Task<bool> UpdateAsync(UserModel user);
    Task<bool> DeleteAsync(UserModel user);
    Task<bool> SaveAsync();

}
