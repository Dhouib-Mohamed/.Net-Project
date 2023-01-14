using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;
using System.Data;
using System.Diagnostics;

namespace project_.net.Controllers
{
    public class HomeController : Controller
    {
        
        ClientRepository repository = new ClientRepository();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                ViewData["NavMenuPage"] = "disconnected";
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Index),nameof(Restaurant));
            }
        }
        public IActionResult Signup(String error)
        {
            ViewBag.error = error;
            if (HttpContext.Session.GetInt32("user")!=1)
            {
                ViewData["NavMenuPage"] = "disconnected";

                return View();
            }
            else
            {
                return RedirectToAction(nameof(Index));   
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(Client c)
        {
            //insert to data base
            
            bool res = repository.SignUp(c);
            if (res)
            {
                HttpContext.Session.SetInt32("user", 1);
                HttpContext.Session.SetInt32("userId", c.Id);
                return RedirectToAction("Index","Restaurant",new{success=$"user {c.Name} is Created Successfully"});
            }
            else
            {
                return RedirectToAction(nameof(Signup),new {error="Error in provided data"});
            }
            // redirect to /Client/index

        }
        public IActionResult Signin(String error)
        {
            ViewBag.error = error;
            if (HttpContext.Session.GetInt32("user")!=1)
            {
                ViewData["NavMenuPage"] = "disconnected";
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signin(Client c)
        {
            
            int res = repository.SignIn(c);
            Debug.Write(res);
            if (res!=-1)
            {
                HttpContext.Session.SetInt32("user", 1);
                HttpContext.Session.SetInt32("userId", res);
                return RedirectToAction("Index","Restaurant",new {success=$"user {c.Name} is Connected Successfully"});
            }
            else
            {
                return RedirectToAction(nameof(Signin),new {error=$"Error in provided data"});
            }
            // redirect to /Client/index
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Signout()
        {
            HttpContext.Session.SetInt32("user", 0);
            HttpContext.Session.SetInt32("userId", -1);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Faker()
        {
            FakeDataGenerator.Clients();
            return RedirectToAction(nameof(Index));
        }
    }
}