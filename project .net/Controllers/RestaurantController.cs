using Microsoft.AspNetCore.Mvc;
using project_.net.Database;
using project_.net.Models;

namespace project_.net.Controllers

{
   
    public class RestaurantController : Controller
    {
        public List<Category> category = new List<Category>(){ new Category("americaine") , new Category("Française") , new Category("Tunisienne") , new Category("italienne") , new Category("lobneniya") };


        public List<Restaurant> RestaurantData = new List<Restaurant>()
        {
            new Restaurant("PastaCosi","Lac","https://media-cdn.tripadvisor.com/media/photo-s/15/5c/32/63/pasta-fruits-de-mer.jpg" , 40),
            new Restaurant("twoM","hammamet","https://media.cntraveler.com/photos/5b22bfdf633da74cbe8bd873/master/w_1200,c_limit/Buca-Yorkville_Rick-O'Brien_2018_BUCA_4SEASONS_092-(8).jpg?mbid=social_retweet",20),
                new Restaurant("baristas","centre urbain nord" ,"https://th.bing.com/th/id/OIP.4Q39EptrW14YfZZ-8vc8mgHaFj?pid=ImgDet&rs=1",40),
                    new Restaurant("khalil","tunis","https://th.bing.com/th/id/R.0a5ff9269f7d485895700daa46b8216c?rik=ks0%2bPBqoLDTWIQ&pid=ImgRaw&r=0",22),
                        new Restaurant("pizza","sokra","https://th.bing.com/th/id/OIP.mudFr3EWGVKiUCzJttcErQHaEi?pid=ImgDet&rs=1",19),
                            new Restaurant("burger","aouina","https://img.tagvenue.com/resize/6f/c6/widen-1680-noupsize;2944-the-restaurant-room.jpg",45),
                            new Restaurant("lasagne","ariana","https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/935c1071711569.5bcee78e4e619.jpg",18),
                            new Restaurant("hiii","nabeul","https://i.pinimg.com/originals/51/61/a9/5161a9904eea6222ec3fdc2f0528504b.jpg",40)

        };

        RestaurantRepository repository = new RestaurantRepository();
        ReservationRepository reservationRepository = new ReservationRepository();
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
                ViewBag.search = collection["search"];
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
        public IActionResult add()
        {
            if (HttpContext.Session.GetInt32("user") == 1)
            {
                RestaurantRepository restaurantRepository = new RestaurantRepository();
                Restaurant restaurant = new Restaurant("hiuypo", "kdfsvb","lids",3); 
                restaurantRepository.addRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Signin","Home");
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