using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;

namespace project_.net.Controllers
{
    public class AdminController : Controller
    {

        readonly ClientRepository _clientRepository = new ClientRepository();

        readonly RestaurantRepository _restaurantRepository = new RestaurantRepository();
        // GET: AdminController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                ViewData["NavMenuPage"] = "admin";

                List<Restaurant> restaurants = _restaurantRepository.getRestaurants();
                List<Client> clients = _clientRepository.getClients();
                ViewBag.Clients = clients;
                ViewBag.Restaurants = restaurants;
                return View();   
            }
        }
        public ActionResult Sign()
        {
            if (HttpContext.Session.GetInt32("admin") != 1)
            {
                ViewData["NavMenuPage"] = "admin";

                return View();
            }
            else {
                return RedirectToAction(nameof(Index));
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sign(IFormCollection collection)
        {
            if (collection["code"] == "nada debla")
            {
                HttpContext.Session.SetInt32("admin",1);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant(IFormCollection collection)
        { 
            Restaurant restaurant = new Restaurant(collection["Name"], collection["Localization"], collection["Image"], Int16.Parse(collection["Places"]));
            _restaurantRepository.addRestaurant(restaurant);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult CreateRestaurant()
        {
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                ViewData["NavMenuPage"] = "admin";
                return View();   
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRestaurant(int id,IFormCollection collection)
        {
            Restaurant restaurant = _restaurantRepository.getRestaurantById(id);
            restaurant.NbPlaces = Int16.Parse(collection["Places"]);
            restaurant.image = collection["Image"];
            restaurant.Name = collection["Name"];
            restaurant.Localization = collection["Localization"];
            _restaurantRepository.editRestaurant(restaurant);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult RestaurantDetails(int id)
        {
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                ViewData["NavMenuPage"] = "admin";
                Restaurant restaurant = _restaurantRepository.getRestaurantById(id);
                return View(restaurant);  
            }
        }

        
        public ActionResult DeleteRestaurant(int id)
        {
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                
                _restaurantRepository.deleteRestaurant(id);
                return RedirectToAction(nameof(Index)); 
            }
        }
        public ActionResult DeleteClient(int id)
        {
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                _clientRepository.deleteClient(id);
                return RedirectToAction(nameof(Index)); 
            }
        }
    }
}
