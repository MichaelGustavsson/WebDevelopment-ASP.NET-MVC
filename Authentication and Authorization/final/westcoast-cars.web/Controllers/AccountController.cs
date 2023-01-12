using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using westcoast_cars.web.ViewModels.Account;
using westcoast_cars.web.ViewModels.Account.Admin;

namespace westcoast_cars.web.Controllers;

[Route("account")]
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet("{returnUrl}")]
    public IActionResult Login([FromQuery] string returnUrl)
    {
        var loginModel = new LoginViewModel();
        if (returnUrl is null) returnUrl = "/vehicles";

        ViewBag.returnUrl = returnUrl;
        return View("Login", loginModel);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (returnUrl is null) returnUrl = "/vehicles";

        ViewBag.returnUrl = returnUrl;

        if (!ModelState.IsValid) return View(model);

        var user = new IdentityUser
        {
            UserName = model.UserName
        };

        var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, false, false);

        if (result.Succeeded)
        {
            return Redirect(returnUrl);
        }

        if (result.IsNotAllowed)
        {
            ModelState.AddModelError("Login", "Gick inte att logga in");
        }
        if (result.IsLockedOut)
        {
            ModelState.AddModelError("Login", "Kontot är låst");
        }

        ModelState.AddModelError("Login", "Något gick fel");
        return View("Login", model);

    }

    [HttpGet("admin/roles")]
    public IActionResult CreateRole()
    {
        var model = new RoleViewModel();
        return View("CreateRole", model);
    }

    [HttpPost("admin/roles")]
    public async Task<IActionResult> CreateRole(RoleViewModel model)
    {
        if (!ModelState.IsValid) return View("CreateRole", model);

        var role = new IdentityRole(model.RoleName!);
        var result = await _roleManager.CreateAsync(role);

        if (result.Succeeded) return RedirectToAction(nameof(CreateRole));

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("CreateRole", error.Description);
        }

        return View("CreateRole", model);
    }

    [HttpGet("admin/register")]
    public IActionResult AddUser()
    {
        var registerModel = new AddUserViewModel();

        registerModel.Role.Roles = LoadRoles().ToList();

        return View("AddUser", registerModel);
    }

    [HttpPost("admin/register")]
    public async Task<IActionResult> AddUser(AddUserViewModel model)
    {
        if (!ModelState.IsValid) return View("AddUser", model);

        // Save user to datastore...
        try
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, model.Role.RoleName!);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AddUser));
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("AddUser", error.Description);
                }

                model.Role.Roles = LoadRoles().ToList();
                return View("AddUser", model);
            }

            return RedirectToAction(nameof(AddUser));
        }
        catch (Exception ex)
        {
            model.Role.Roles = LoadRoles().ToList();
            ModelState.AddModelError("AddUser", ex.Message);
            return View("AddUser", model);
        }
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        var registerModel = new RegisterUserViewModel();
        return View("Register", registerModel);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {
        if (!ModelState.IsValid) return View("Register", model);

        var user = new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password!);

        if (result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(user, "Användare");

            if (result.Succeeded) return RedirectToRoute(new { controller = "Vehicles", action = "Index" });

            return RedirectToRoute(new { controller = "Vehicles", action = "Index" });
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Registrera", error.Description);
            }
            return View("Register", model);
        }
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToRoute(new { controller = "home", action = "index" });
    }

    private IList<SelectListItem> LoadRoles()
    {

        var roles = new List<SelectListItem>();

        if (_roleManager.SupportsQueryableRoles)
        {
            foreach (var role in _roleManager.Roles)
            {
                roles.Add(new SelectListItem { Value = role.Name, Text = role.Name });
            }
        }
        else
        {
            roles.Add(new SelectListItem { Value = "admin", Text = "Administratör" });
            roles.Add(new SelectListItem { Value = "user", Text = "Försäljare" });
            roles.Add(new SelectListItem { Value = "management", Text = "Chef" });
        }

        return roles;
    }
}