using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;

namespace project_.net.Controllers
{
    public class ProfileController : Controller
    {
        ClientRepository rep1 = new ClientRepository();
        public IActionResult ProfileDetails()
        {
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("Signin","Home");
            }
            else
            {
                ViewData["NavMenuPage"] = "profile";
                Client c = rep1.getClientById(1);
                return View(c);
            }
        
    }
        ReservationRepository rep2 = new ReservationRepository();
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
        public IActionResult Edit()
        {
            ViewData["NavMenuPage"] = "profile";
            return View();
        }

    }
}
