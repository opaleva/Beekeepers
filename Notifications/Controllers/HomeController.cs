using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Notifications.Models;

namespace Notifications.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int hour = DateTime.Now.Hour;
        string user = "дорогой пчеловод";
        switch (hour)
        {
            case < 6:
                ViewBag.Hello = $"Доброй ночи, {user} :)";
                break;
            case < 12:
                ViewBag.Hello = $"Доброе утро, {user} :)";
                break;
            case > 18:
                ViewBag.Hello = $"Добрый вечер, {user} :)";
                break;
            default:
                ViewBag.Hello = $"Добрый день, {user} :)";
                break;
        }
        return View();
    }

    [HttpGet]
    public IActionResult RequestForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RequestForm(Participant participant)
    {
        if (ModelState.IsValid)
            return View("Accepted", participant);
        return View();
    }
    
    // public IActionResult Schedule()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}