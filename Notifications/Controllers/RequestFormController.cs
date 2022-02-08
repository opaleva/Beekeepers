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
    public IActionResult Index(Participant participant)
    {
        if (ModelState.IsValid)
            return View("Accepted", participant);
        return View();
    }
}