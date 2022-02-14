using Microsoft.AspNetCore.Mvc;

namespace Conference.Controllers;

public class BeekeepersListController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}