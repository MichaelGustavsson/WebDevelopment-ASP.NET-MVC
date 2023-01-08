using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace westcoast_cars.web.Controllers;

[Route("services")]
[Authorize()]
public class ServicesController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }

}
