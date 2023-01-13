using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;

namespace project_.net.Controllers
{
    public class AdminController : Controller
    {

        ClientRepository clientRepository = new ClientRepository();
        RestaurantRepository restaurantRepository = new RestaurantRepository();
        // GET: AdminController
        public ActionResult Index()
        {
            List<Restaurant> restaurants = restaurantRepository.getRestaurants();
           // List<Client> clients = clientRepository.getClients();
           // ViewBag.Clients = clients;
            ViewBag.Restaurants = restaurants;
            return View();


        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant(IFormCollection collection)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRestaurant(int id, IFormCollection collection)
        {
            return View();
        }

        
        public ActionResult DeleteRestaurant(int id, IFormCollection collection)
        {
            restaurantRepository.deleteRestaurant(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DeleteClient(int id, IFormCollection collection)
        {
            clientRepository.deleteClient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
