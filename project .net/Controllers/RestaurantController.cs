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
            if (HttpContext.Session.GetInt32("user")!=1)
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
            if (HttpContext.Session.GetInt32("user")!=1)
            {
                return RedirectToAction("/Home/Signin");

            }
            else
            {
                Restaurant restaurant = repository.getRestaurantById(id);
                return View(restaurant);

            }
         
        }
        
        public IActionResult Faker()
        {
            if (HttpContext.Session.GetInt32("user")==1)
            {
                FakeDataGenerator.Restaurants();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("/Home/Signin");
            }
        }
        /*
        public IActionResult ListeRestaurant()
        {
            var restaurants = getlist();

            return View(restaurants);
        }

        public IActionResult ListePlat(int id)
        {
            var restaurantbyid = getlist().SingleOrDefault(r => r.Id == id);
            if (restaurantbyid == null | restaurantbyid.Plats == null) 
            {
                return Content(
                    "<script> alert('restaurant non trouvé') </script>");
            }
            else
            { return View(restaurantbyid);
               
            }
        }


        public IEnumerable<Restaurant> getlist()
        {
            
                Restaurant restaurant1 = new Restaurant()
                    { Id = 1, Localisation = "manar", Name = "rest1", speciality = "tunisienne" , Plats = new List<Plat>(){ new Plat() { plat_Id = 1, plat_name = "pizza", ingrediants = "ddDdscdsc" } ,
                            new Plat() { plat_Id = 2, plat_name = "pizza", ingrediants = "ddDdscdsc" }

                    }};
                Restaurant restaurant2 = new Restaurant()
                    { Id = 2, Localisation = "sokra", Name = "rest2", speciality = "italienne" };
                List<Restaurant> restaurants = new List<Restaurant>() { restaurant1, restaurant2 };
                return restaurants;
            }
        */
    }

}
