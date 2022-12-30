
using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Data;
using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Repository;

public class UserRepository : Repository<UserModel>, IUserRepository
{
    public UserRepository(WestcoastCarsContext context) : base(context) { }

    public async Task<UserModel?> FindByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(c => c.Email.Trim().ToLower() ==
            email.Trim().ToLower());
    }
}
