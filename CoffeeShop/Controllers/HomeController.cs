using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private CoffeeShopMVCContext context = new CoffeeShopMVCContext();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // methods that return the view
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    // methods that function with the DB

    public IActionResult AddUserToDb(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return RedirectToAction("ThankYouSignUp", user); // go to view of all users 
    }

    public IActionResult ThankYouSignUp(User user)
    {
        List<User> newUser = new List<User>()
        {
            user
        };
        return View(newUser);

    }
    public IActionResult ShowAllUsers()
    {
        List<User> users = context.Users.ToList();
        return View(users);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

