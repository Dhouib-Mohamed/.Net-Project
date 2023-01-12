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
                Restaurant r = new Restaurant( Faker.Company.Name(), Faker.Address.StreetName(), "https://cdn2.vectorstock.com/i/1000x1000/23/36/lettering-hi-vector-26522336.jpg", Faker.RandomNumber.Next(5, 50));
                r.categories.Add(c);
                context.Restaurant.Add(r);
                context.SaveChanges();
            }
        }
    }
}