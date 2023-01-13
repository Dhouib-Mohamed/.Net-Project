using Microsoft.AspNetCore.Mvc;

namespace project_.net.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfileDetails()
        {
            
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
