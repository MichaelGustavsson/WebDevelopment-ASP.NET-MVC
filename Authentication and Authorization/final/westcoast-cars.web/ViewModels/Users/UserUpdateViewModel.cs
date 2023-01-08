using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_cars.web.ViewModels.Users;

public class UserUpdateViewModel
{
    [Required(ErrorMessage = "Användar Id är obligatoriskt")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Användarnamn är obligatoriskt")]
    [DisplayName("Användarnamn")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "Förnamn är obligatoriskt")]
    [DisplayName("Förnamn")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Efternamn är obligatoriskt")]
    [DisplayName("Efternamn")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "E-Post adress är obligatoriskt")]
    [DisplayName("E-Post")]
    public string Email { get; set; } = "";

    public string Password { get; set; } = "";
}
