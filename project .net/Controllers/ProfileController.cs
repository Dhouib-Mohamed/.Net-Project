using System.Diagnostics;
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
                ViewData["NavMenuPage"] = "connected";
                Client c = rep1.getClientById(HttpContext.Session.GetInt32("userId")??-1);
                return View(c);
            }
        
    }
        ReservationRepository rep2 = new ReservationRepository();
        public IActionResult History(String success)
        {
            ViewBag.success = success;
        if (HttpContext.Session.GetInt32("user")!=1)
            {
                return RedirectToAction("Signin","Home");
            }
            else
            {            ViewData["NavMenuPage"] = "connected";

            var r = rep2.getReservationsByClientId(HttpContext.Session.GetInt32("userId") ?? -1);
            return View(r);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            Client c = rep1.getClientById(id);
            c.Name = collection["Name"];
            c.email = collection["email"];
            c.password = collection["password"];
            c.phoneNumber = collection["phone"];
            rep1.editClient(c);
            return RedirectToAction(nameof(ProfileDetails));
        }

        public ActionResult DeleteReservation(int id)
        {
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("Signin", "Home");
            }
            else
            {
                rep2.deleteReservation(id);
                return RedirectToAction(nameof(History),new {success =$"Reservation {id} is Deleted Successfully"});
            }
        }
    }
}
