using Microsoft.AspNetCore.Mvc;

namespace westcoast_cars.web.Controllers;

public class HomeController : Controller
{

    // Action method...
    public IActionResult Index()
    {
        ViewBag.Message = "Vi har bilen för dig och din familj!!!";
        // Returnerar ett ViewResult...
        return View("Index");
    }
}
