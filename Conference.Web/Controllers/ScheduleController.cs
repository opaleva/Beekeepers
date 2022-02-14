using Microsoft.AspNetCore.Mvc;

namespace Conference.Controllers;

public class ScheduleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return this.View(viewName: "Index");
    }
}