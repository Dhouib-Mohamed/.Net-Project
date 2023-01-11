using project_.net.Models;

namespace project_.net.Database
{
    public class FakeDataGenerator
    {
        public static void Restaurants() {
            for (int i =0; i < 20; i++)
            {
                RestaurantRepository restaurantRepository= new RestaurantRepository();
                Restaurant r = new Restaurant(Faker.Company.Name(),Faker.Address.StreetName(), "https://cdn2.vectorstock.com/i/1000x1000/23/36/lettering-hi-vector-26522336.jpg");
                restaurantRepository.addRestaurant(r);
            }
        }
    }
}
