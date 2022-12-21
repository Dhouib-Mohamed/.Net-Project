using Microsoft.AspNetCore.Mvc;

namespace project_.net.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
