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
            ViewData["NavMenuPage"] = "profile";
            Client c = rep1.getClientById(1);
            return View(c);
        }
        ReservationRepository rep2 = new ReservationRepository();
        public IActionResult History()
        {
            Reservation r = rep2.getReservationByClientId(1);
            ViewData["NavMenuPage"] = "profile";
            return View(r);
        }
        public IActionResult Edit()
        {
            ViewData["NavMenuPage"] = "profile";
            return View();
        }
    }
}
