using project_.net.Models;
using project_.net.Models.project_.net.Models;

namespace project_.net.Database
{
    public class FakeDataGenerator
    {
        public static void Clients()
        {
            Context context = Context.getInstance();

            for (int i = 0; i < 20; i++)
            {
               
                Client r = new Client(){ Name=Faker.Name.FullName(), email = Faker.Name.Middle(), password = Faker.Address.Country(), phoneNumber = Faker.Phone.Number()};
                context.Client.Add(r);
                context.SaveChanges();
            }
            
        }
        public static void Restaurants()
        {
        }
       /* for (int i =0; i < 20; i++)
            {
                RestaurantRepository restaurantRepository= new RestaurantRepository();
                Restaurant r = new Restaurant(i,Faker.Company.Name(),Faker.Address.StreetName(), "https://cdn2.vectorstock.com/i/1000x1000/23/36/lettering-hi-vector-26522336.jpg",Faker.RandomNumber.Next(5,50),Faker.RandomNumber.Next(0,20));
                restaurantRepository.addRestaurant(r);
            }
        }
       */
       public static void Category()
       {
       } 
      /* for (int i = 0; i < 20; i++)
            {
                RestaurantRepository restaurantRepository = new RestaurantRepository();
                Category c = new Category(i, Faker.Country.Name());
                restaurantRepository.addCategory(c);
            }
        }*/
    }
}
