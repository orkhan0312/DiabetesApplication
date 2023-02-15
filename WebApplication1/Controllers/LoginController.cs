using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
/*[Route("[controller]")]
[ApiController]*/
public class LoginController : Controller
{
    private readonly DiabetesDbContext _diabetesDbContext;

    public LoginController(DiabetesDbContext diabetesDbContext )
    {
        _diabetesDbContext = diabetesDbContext;
    }
    // GET
    public IActionResult Index()
    {
        string errorMessage = TempData["ErrorMessage"]?.ToString();

        // Pass the error message to the view
        ViewData["ErrorMessage"] = errorMessage;
        return View();
    }

    public async Task<IActionResult> Login(string username, string password, bool rememberMe = false)
    {
        
            User result = _diabetesDbContext.Users.FirstOrDefault(o => o.Username == username);
            if (result != null)
            {
                if (result.Password == password)
                {
                    HttpContext.Session.SetString("username", username);
                    
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = rememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

                    return RedirectToAction("Index", "UserMenu");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Wrong Credentials, try again!";
                return RedirectToAction("Index", "Login");
            }

            
        
        if (username == "orkhan@gmail.com")
        {
            // Set the username in session
            HttpContext.Session.SetString("username", username);
            return RedirectToAction("Index", "UserMenu");
        }
        else
        {
            TempData["ErrorMessage"] = "An error occurred while doing something.";
            return RedirectToAction("Index", "Login");
        }
    }

    public IActionResult Logout()
    {
        // Get the session
        var session = HttpContext.Session;

        // Clear the session
        session.Clear();

        return RedirectToAction("Index", "Home");
    }
}