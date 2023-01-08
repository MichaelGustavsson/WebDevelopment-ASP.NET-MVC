using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_cars.web.ViewModels.Account.Admin;

public class AddUserViewModel
{
    [Required(ErrorMessage = "E-post saknas")]
    [EmailAddress(ErrorMessage = "Felaktig e-post adress")]
    [DisplayName("E-Post")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Lösenord saknas")]
    [DisplayName("Lösenord")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public RoleViewModel Role { get; set; } = new RoleViewModel();
}
