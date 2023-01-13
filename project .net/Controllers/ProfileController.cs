﻿using Microsoft.AspNetCore.Mvc;
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
                Client c = rep1.getClientById(HttpContext.Session.GetInt32("userId")??-1);
                return View(c);
            }
        
    }
        ReservationRepository rep2 = new ReservationRepository();
        public IActionResult History()
        {
            ViewData["NavMenuPage"] = "profile";
        if (HttpContext.Session.GetInt32("user")!=1)
            {
                return RedirectToAction("Signin","Home");
            }
            else
            {
            var r = rep2.getReservationsByClientId(HttpContext.Session.GetInt32("userId") ?? -1);
            return View(r);
            }
        }



        public IActionResult Edit()
        {
            ViewData["NavMenuPage"] = "profile";
            return View();
        }
    }
}
