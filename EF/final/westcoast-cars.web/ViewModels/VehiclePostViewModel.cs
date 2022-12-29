using System.ComponentModel.DataAnnotations;

namespace westcoast_cars.web.ViewModels;

public class VehiclePostViewModel
{
    public string VinNumber { get; set; } = "";

    [Required(ErrorMessage = "Registreringsnummer är obligatoriskt")]
    public string RegistrationNumber { get; set; } = "";

    [Required(ErrorMessage = "Tillverkare är obligatoriskt")]
    public string Manufacturer { get; set; } = "";

    [Required(ErrorMessage = "Modell är obligatoriskt")]
    public string Model { get; set; } = "";

    [Required(ErrorMessage = "Modell år är obligatoriskt")]
    public string ModelYear { get; set; } = "";

    [Required(ErrorMessage = "Antal körda km är obligatoriskt")]
    [Range(1, int.MaxValue, ErrorMessage = "Antal körda km är obligatoriskt och måste vara större än 0.")]
    public int? Mileage { get; set; }
}
