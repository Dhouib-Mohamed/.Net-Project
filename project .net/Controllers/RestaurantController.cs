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
          //  RestaurantRepository repository = new RestaurantRepository();
         Restaurant restaurant = repository.getRestaurantByid(id);
         return View(restaurant);
        }

        public IActionResult book()
        {
           
            return View();
        }
        public IActionResult Faker()
        {
            FakeDataGenerator.Restaurants();
            return RedirectToAction(nameof(Index));
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
