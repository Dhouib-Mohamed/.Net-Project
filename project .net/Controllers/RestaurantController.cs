using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;

namespace project_.net.Controllers
{
    public class RestaurantController : Controller
    {
        RestaurantRepository repository = new RestaurantRepository();
        public IActionResult Index()
        {
            var restaurants = repository.getRestaurants();

            return View(restaurants);
        }

        
        public IActionResult restaurant_detail(int id)
        {
          
         Restaurant restaurant = repository.getRestaurantById(id);
         return View(restaurant);
        }
        
        public IActionResult Faker()
        {
            FakeDataGenerator.Restaurants();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult book()
        {
            return View();
        }
        [HttpPost]
        public IActionResult book(DateOnly date , int nbre)
        {
            return RedirectToRoute("/ProfileController/myReservations");
        }


    }

}
