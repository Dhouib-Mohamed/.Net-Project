using Microsoft.AspNetCore.Mvc;
using project_.net.Models;
using System.Diagnostics;
using project_.net.Database;

namespace project_.net.Controllers
{
    public class HomeController : Controller
    {
        ClientRepository clientRepository = new ClientRepository();

        public IActionResult Index()
        {
            List<Client> clients = clientRepository.getClients();
            return View(clients);
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