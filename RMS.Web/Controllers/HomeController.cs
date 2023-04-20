using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RMS.Web.Models;

namespace RMS.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        var about = new AboutViewModel {
            Title = "About",
            Message = "Our mission is to develop great recipes for healthy eating",
            Formed = new DateTime(2000,10,1)
        };
        return View(about);
    }

    public IActionResult Contact()
    {
        var contact = new ContactViewModel {
            Title = "Contact",
            Message = "Meet the team"
            
        };
        return View(contact);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
