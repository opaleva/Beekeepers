using Microsoft.AspNetCore.Mvc;

namespace Notifications.Controllers;

public class ScheduleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return this.View(viewName: "Index");
    }
}