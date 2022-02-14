using Microsoft.AspNetCore.Mvc;

namespace Notifications.Controllers;

public class BeekeepersListController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}