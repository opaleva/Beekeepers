using Microsoft.AspNetCore.Mvc;
using Notifications.Models;

namespace Notifications.Controllers;

public class RequestFormController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(Beekeeper beekeeper)
    {
        if (ModelState.IsValid)
            return View("Accepted", beekeeper);
        return View();
    }
}