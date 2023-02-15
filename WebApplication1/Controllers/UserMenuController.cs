using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[Authorize]
public class UserMenuController : Controller
{
    private readonly DiabetesDbContext _context;

    public UserMenuController(DiabetesDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        var users = _context.Users.ToList();

        /*var viewModel = new User.UsersViewModel { Users = users };*/

        return View(users);
    }
}