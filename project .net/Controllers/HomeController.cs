using Microsoft.AspNetCore.Mvc;
using project_.net.Models;
using System.Diagnostics;
using project_.net.Database;
using project_.net.Models.project_.net.Models;

namespace project_.net.Controllers
{
    public class HomeController : Controller
    {
       

        

        public IActionResult Index()
        { FakeDataGenerator.Clients();
            return View();
        }

        public IActionResult Privacy()
        { Context context = Context.getInstance();
            List<Client> clients = context.Client.ToList();
            return View(clients);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}