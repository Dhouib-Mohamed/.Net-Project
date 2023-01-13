using project_.net.Models;

namespace project_.net.Database
{
    public class FakeDataGenerator
    {
        public static void Clients()
        {
            Context context = Context.getInstance();

            for (int i = 0; i < 20; i++)
            {
                Client r = new Client(Faker.Name.FullName(), Faker.Name.Middle(), Faker.Address.Country(), Faker.Phone.Number());
                context.Client.Add(r);
                context.SaveChanges();
            }
        }

        public static void Restaurants()
        {
            Context context = Context.getInstance();
            for (int i = 0; i < 20; i++)
            {
                Category c = new Category(Faker.Name.Suffix());
                RestaurantRepository restaurantRepository = new RestaurantRepository();
                Restaurant r = new Restaurant(Faker.Company.Name(), Faker.Address.StreetName(), "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Barbieri_-_ViaSophia25668.jpg/435px-Barbieri_-_ViaSophia25668.jpg", Faker.RandomNumber.Next(5, 50));
                r.categories.Add(c);
                context.Restaurant.Add(r);
                context.SaveChanges();
            }
        }
    }
}