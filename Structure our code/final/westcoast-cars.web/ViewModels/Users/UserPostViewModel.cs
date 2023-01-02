using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_cars.web.ViewModels.Users;

public class UserPostViewModel
{
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

    [Required(ErrorMessage = "Ett standard lösenord är obligatoriskt")]
    [DisplayName("Temporärt lösenord")]
    public string Password { get; set; } = "";
}