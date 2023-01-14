using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;

namespace project_.net.Controllers
{
    public class RestaurantController : Controller
    {
        RestaurantRepository repository = new RestaurantRepository();
        public IActionResult Index(String success)
        {
            ViewBag.success = success;
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("Signin", "Home");
            }
            else
            {
                ViewData["NavMenuPage"] = "connected";
                var restaurants = repository.getRestaurants();
                return View(restaurants);
            }
        }
        [HttpPost]
        public IActionResult RestaurantsByName(IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("user") != 1)
            {
                return RedirectToAction("Signin", "Home");
            }
            else
            {
                ViewData["NavMenuPage"] = "connected";
                var restaurants = repository.RestaurantListByName(collection["search"]);
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
                ViewData["NavMenuPage"] = "connected";
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
        public IActionResult book(int id)
        {
            ViewData["NavMenuPage"] = "connected";
            ViewBag.id = id;
            return View(id);
        }
        [HttpPost]
        public IActionResult book(IFormCollection collection,int id)
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            reservationRepository.addReservation(HttpContext.Session.GetInt32("userId")??-1,id,DateTime.Parse(collection["Date"]),Int32.Parse(collection["Places"]));
            return RedirectToAction(nameof(Index),new {success=$"Reservation {id} is Created Successfully"});
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

}
*/