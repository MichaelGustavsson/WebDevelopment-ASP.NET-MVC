using System.Text.Json;
using westcoast_cars.web.Models;

namespace westcoast_cars.web.Data;

public static class SeedData
{
    public static async Task LoadVehicleData(WestcoastCarsContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Vill endast ladda data om databasens tabell är tom...
        if (context.Vehicles.Any()) return;

        // Läsa in json datat...
        var json = System.IO.File.ReadAllText("Data/json/vehicles.json");
        // Konvertera json objekten till en lista av Vehicle objekt...
        var vehicles = JsonSerializer.Deserialize<List<VehicleModel>>(json, options);

        if (vehicles is not null && vehicles.Count > 0)
        {
            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();
        }
    }
}
