using Microsoft.AspNetCore.Mvc;

namespace project_.net.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfileDetails()
        {
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("/Home/Signin");
            }
            else
            {
                return View();
            }
        }
        public IActionResult History()
        {
            if (HttpContext.Session.GetInt32("user")!=1)
            {
                return RedirectToAction("Signin","Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult myReservations()
        {
            return View();
        }

    }
}
