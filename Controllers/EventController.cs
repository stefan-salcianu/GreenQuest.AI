using Microsoft.AspNetCore.Mvc;

namespace GreenQuest.AI.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
