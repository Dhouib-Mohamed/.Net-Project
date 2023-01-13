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
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("Signin", "Home");
            }
            else
            {
                var restaurants = repository.getRestaurants();
                return View(restaurants);
            }
        }


        public IActionResult restaurant_detail(int id)
        {
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("Signin","Home");

            }
            else
            {
                Restaurant restaurant = repository.getRestaurantById(id);
                return View(restaurant);

            }

        }

        public IActionResult Faker()
        {
            if (HttpContext.Session.GetInt32("user") == 1)
            {
                FakeDataGenerator.Restaurants();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Signin","Home");
            }
        }
        [HttpGet]
        public IActionResult book()
        {
            return View();
        }
    }
}
/*
public IActionResult ListeRestaurant()
{
    var restaurants = getlist();

[HttpGet]
public IActionResult book()
{
    return View();
}

}

}*/
