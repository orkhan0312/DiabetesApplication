using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class RegisterController : Controller
{
    private readonly DiabetesDbContext _context;

    public RegisterController(DiabetesDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Index", "UserMenu");
    }

    public IActionResult Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index", "UserMenu");
    }

}