using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Data;

public class WestcoastCarsContext : IdentityDbContext
{
    public DbSet<VehicleModel> Vehicles => Set<VehicleModel>();
    public WestcoastCarsContext(DbContextOptions options) : base(options)
    {
    }
}
