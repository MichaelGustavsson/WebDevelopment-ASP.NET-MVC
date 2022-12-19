using Microsoft.AspNetCore.Mvc;

namespace westcoast_cars.web.Controllers;

public class HomeController : Controller
{
    // url: https://localhost:7018/home/index...
    public IActionResult Index()
    {
        return View("Index");
        // return Content("Hej på Er!!!");
        // return File();
    }
}
