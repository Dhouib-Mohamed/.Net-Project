using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;
using System.Data;
using System.Diagnostics;

namespace project_.net.Controllers
{
    public class HomeController : Controller
    {
        ClientRepository clientRepository = new ClientRepository();

        public IActionResult Index()
        {
            
            return View();
            
        }
        public IActionResult Signup()
        {
            if (HttpContext.Session.GetInt32("user")!=1)
            {
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
            ClientRepository repository = new ClientRepository();
            bool res = repository.SignUp(c);
            if (res)
            {
                HttpContext.Session.SetInt32("user", 1);
                HttpContext.Session.SetInt32("userId", c.Id);
                return RedirectToAction("Index","Restaurant");
            }
            // redirect to /Client/index
            return View();

        }
        public IActionResult Signin()
        {
            if (HttpContext.Session.GetInt32("user")!=1)
            {
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
            ClientRepository repository = new ClientRepository();
            int res = repository.SignIn(c);
            if (res!=-1)
            {
                HttpContext.Session.SetInt32("user", 1);
                HttpContext.Session.SetInt32("userId", c.Id);
                return RedirectToAction("Index","Restaurant");
            }
            // redirect to /Client/index
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Faker()
        {
            FakeDataGenerator.Clients();
            return RedirectToAction(nameof(Index));
        }
    }
}