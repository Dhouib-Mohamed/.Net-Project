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
        public ActionResult Index(String success="")
        {
            ViewBag.success = success;
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                ViewData["NavMenuPage"] = "Admin";

                List<Restaurant> restaurants = _restaurantRepository.getRestaurants();
                List<Client> clients = _clientRepository.getClients();
                ViewBag.Clients = clients;
                ViewBag.Restaurants = restaurants;
                return View();   
            }
        }
        public ActionResult Sign(String error="")
        {
            ViewBag.error = error;
            if (HttpContext.Session.GetInt32("admin") != 1)
            {
                ViewData["NavMenuPage"] = "default";
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
                return RedirectToAction(nameof(Index),new {success="Admin Access Granted"});
            }
            else
            {
                return RedirectToAction(nameof(Sign), new { error = "Incorrect code" });
            }
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant(IFormCollection collection)
        {
            Restaurant restaurant = new Restaurant(collection["Name"], collection["Localization"], collection["Image"], Int16.Parse(collection["Places"]));
            _restaurantRepository.addRestaurant(restaurant);
            return RedirectToAction(nameof(Index),new {success="Restaurant Created Successfully"});
        }
        public ActionResult CreateRestaurant()
        {
            if (HttpContext.Session.GetInt32("admin")!=1)
            {
                return RedirectToAction(nameof(Sign));
            }
            else
            {
                ViewData["NavMenuPage"] = "Admin";
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
            return RedirectToAction(nameof(Index),new {success="Restaurant Changed Successfully"});
        }
        public IActionResult Signout()
        {
            HttpContext.Session.SetInt32("admin", 0);
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
                return RedirectToAction(nameof(Index),new {success="Restaurant Deleted Successfully"}); 
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
                return RedirectToAction(nameof(Index),new {success="Client Created Successfully"}); 
            }
        }
    }
}
