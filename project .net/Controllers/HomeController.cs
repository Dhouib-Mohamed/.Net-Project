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
           // List<Client> clients = clientRepository.getClients();
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(Client c)
        {
            //insert to data base
            Context context = Context.Instatiate_Context();
            ClientRepository repository = new ClientRepository();
            repository.add(c);
            // redirect to /Client/index
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(Client c)
        {
            Context context = Context.Instatiate_Context();
            IEnumerable<Client> clients =
                (IEnumerable<Client>)context.Client.Where(e => e.email == c.email && e.password == c.password);
            if (clients.Count() == 0)
            {
                ViewBag.NotFound = true;
            }

            return View();
        }

        public IActionResult Privacy()
        {
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