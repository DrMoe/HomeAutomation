using Microsoft.AspNetCore.Mvc;

namespace Home_Automation.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
