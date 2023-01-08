using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using westcoast_cars.web.ViewModels.Account.Admin;

namespace westcoast_cars.web.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "E-post saknas")]
        [EmailAddress(ErrorMessage = "Felaktig e-post adress")]
        [DisplayName("E-Post")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Lösenord saknas")]
        [DisplayName("Lösenord")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Bekräfta lösenord saknas")]
        [DisplayName("Bekräfta lösenord")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lösenord och bekräfta lösenord matchar inte")]
        public string? ConfirmPassword { get; set; }
    }
}