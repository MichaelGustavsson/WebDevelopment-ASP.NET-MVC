using Microsoft.AspNetCore.Mvc;

namespace westcoast_cars.web.Controllers;

[Route("users/admin")]
public class UsersAdminController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }
}
