using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Data;

public class WestcoastCarsContext : DbContext
{
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<UserModel> Users => Set<UserModel>();
    public WestcoastCarsContext(DbContextOptions options) : base(options)
    {
    }
}
