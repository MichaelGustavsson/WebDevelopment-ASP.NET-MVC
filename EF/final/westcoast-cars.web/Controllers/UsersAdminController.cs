using Microsoft.AspNetCore.Mvc;
using westcoast_cars.web.Interfaces;
using westcoast_cars.web.Models;
using westcoast_cars.web.ViewModels.Users;

namespace westcoast_cars.web.Controllers;

[Route("users/admin")]
public class UsersAdminController : Controller
{
    private readonly IUserRepository _repo;
    public UsersAdminController(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _repo.ListAllAsync();
        var users = result.Select(u => new UsersListViewModel
        {
            UserId = u.UserId,
            UserName = u.UserName,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email
        }).ToList();

        return View("Index", users);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var user = new UserPostViewModel();
        return View("Create", user);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(UserPostViewModel user)
    {
        if (!ModelState.IsValid) return View("Create", user);

        if (await _repo.FindByEmailAsync(user.Email) is not null)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Användare finns redan",
                ErrorMessage = $"Användare med e-post {user.Email} finns redan upplagd!"
            };
            return View("_Error", error);
        }

        var userToAdd = new UserModel
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password
        };

        if (await _repo.AddAsync(userToAdd))
        {
            if (await _repo.SaveAsync())
            {
                return RedirectToAction(nameof(Index));
            }
        }

        return View("_Error", new ErrorModel { ErrorTitle = "Gick inte att spara användare", ErrorMessage = $"Ett fel inträffade när användare {user.FirstName} {user.LastName} skulle sparas" });
    }

    [HttpGet("edit/{userId}")]
    public async Task<IActionResult> Edit(int userId)
    {

        var result = await _repo.FindByIdAsync(userId);

        if (result is null)
        {
            return View("_Error", new ErrorModel { ErrorTitle = "Kunde inte hitta användare", ErrorMessage = $"Vi kunde inte hitta någon användare med id {userId}" });
        }

        var userToUpdate = new UserUpdateViewModel
        {
            UserId = result.UserId,
            UserName = result.UserName,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Email = result.Email
        };

        return View("Edit", userToUpdate);
    }

    [HttpPost("edit/{userId}")]
    public async Task<IActionResult> Edit(int userId, UserUpdateViewModel user)
    {
        try
        {
            if (!ModelState.IsValid) return View("Edit", user);

            var userToUpdate = await _repo.FindByIdAsync(userId);

            if (userToUpdate is null)
            {
                var notFoundError = new ErrorModel
                {
                    ErrorTitle = "Användare saknas!",
                    ErrorMessage = $"Det gick inte att hitta användaren {user.FirstName} {user.LastName}"
                };

                return View("_Error", notFoundError);
            }

            userToUpdate.UserName = user.UserName;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;

            if (await _repo.UpdateAsync(userToUpdate))
            {
                if (await _repo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View("_Error", new ErrorModel { ErrorTitle = "Ett fel inträffade", ErrorMessage = "Något gick fel när användaren skulle uppdateras" });
        }
        catch (Exception ex)
        {
            return View("_Error", new ErrorModel { ErrorTitle = "Ett fel har inträffat", ErrorMessage = ex.Message });
        }
    }

    [Route("delete/{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        try
        {
            var userToDelete = await _repo.FindByIdAsync(userId);

            if (userToDelete is null) return RedirectToAction(nameof(Index));

            if (await _repo.DeleteAsync(userToDelete))
            {
                if (await _repo.SaveAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View("_Error", new ErrorModel { ErrorTitle = "Ett fel inträffade när användaren skulle tas bort", ErrorMessage = $"Ett fel inträffade när användare med id {userId} skulle raderas" });
        }
        catch (Exception ex)
        {
            return View("_Error", new ErrorModel { ErrorTitle = "Ett fel har inträffat", ErrorMessage = ex.Message });
        }
    }

}
