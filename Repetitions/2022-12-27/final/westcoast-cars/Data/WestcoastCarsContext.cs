using Microsoft.EntityFrameworkCore;
using westcoast_cars.Models;

namespace westcoast_cars.Data;

public class WestcoastCarsContext : DbContext
{
    public DbSet<VehicleModel> Vehicles => Set<VehicleModel>();
    public WestcoastCarsContext(DbContextOptions options) : base(options) { }
}
