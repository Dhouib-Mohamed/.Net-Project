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
            if (HttpContext.Session.GetInt32("user")!=1)
            {
                return RedirectToAction(nameof(Signin));
            }
            else
            {
                return View();
            }
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
            Debug.Write("hi");
            //insert to data base
            HttpContext.Session.SetInt32("user", 1);
            ClientRepository repository = new ClientRepository();
            repository.add(c);
            Debug.Write(HttpContext.Session.GetInt32("user"));
            HttpContext.Session.SetInt32("userId", c.Id);
            // redirect to /Client/index
            return RedirectToAction(nameof(Index));
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
            Context context = Context.Instatiate_Context();
            IEnumerable<Client> clients =
                (IEnumerable<Client>)context.Client.Where(e => e.email == c.email && e.password == c.password);
            if (clients.Count() == 0)
            {
                ViewBag.NotFound = true;
            }
            
            HttpContext.Session.SetInt32("user", 1);
            HttpContext.Session.SetInt32("userId", c.Id);
            return RedirectToAction(nameof(Index));
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