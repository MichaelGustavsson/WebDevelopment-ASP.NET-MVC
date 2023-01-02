using Microsoft.AspNetCore.Mvc;

namespace westcoast_cars.web.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }
}
