using westcoast_cars.web.Models;

namespace westcoast_cars.web.Interfaces;

public interface IUserRepository : IRepository<UserModel>
{
    Task<UserModel?> FindByEmailAsync(string email);
}
