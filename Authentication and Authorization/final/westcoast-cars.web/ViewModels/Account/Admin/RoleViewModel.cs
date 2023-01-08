using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace westcoast_cars.web.ViewModels.Account.Admin;

public class RoleViewModel
{
    [Required(ErrorMessage = "Namn på rollen saknas")]
    [DisplayName("Roll")]
    public string? RoleName { get; set; }

    public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
}
