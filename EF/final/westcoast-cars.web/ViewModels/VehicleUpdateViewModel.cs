using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_cars.web.ViewModels;
public class VehicleUpdateViewModel
{
    [Required(ErrorMessage = "Fordons id är obligatoriskt")]
    public int VehicleId { get; set; }
    public string VinNumber { get; set; } = "";

    [Required(ErrorMessage = "Registreringsnummer är obligatoriskt")]
    [DisplayName("Registrerings nummer")]
    public string RegistrationNumber { get; set; } = "";

    [Required(ErrorMessage = "Tillverkare är obligatoriskt")]
    [DisplayName("Tillverkare(Märke)")]
    public string Manufacturer { get; set; } = "";

    [Required(ErrorMessage = "Modell är obligatoriskt")]
    [DisplayName("Modell benämning")]
    public string Model { get; set; } = "";

    [Required(ErrorMessage = "Modell år är obligatoriskt")]
    [DisplayName("Modell År")]
    public string ModelYear { get; set; } = "";

    [Required(ErrorMessage = "Antal körda km är obligatoriskt")]
    [Range(1, int.MaxValue, ErrorMessage = "Antal körda km är obligatoriskt och måste vara större än 0.")]
    [DisplayName("Antal körda km")]
    public int? Mileage { get; set; }
}
