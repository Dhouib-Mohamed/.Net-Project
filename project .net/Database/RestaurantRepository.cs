using project_.net.Database;
using project_.net.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public class RestaurantRepository
{
	Context context=Context.getInstance();
	public RestaurantRepository()
	{
		context = Context.getInstance();

    }
	public void addRestaurant(Restaurant restaurant)
	{
		context.Restaurant.Add(restaurant);
		context.SaveChanges();
	}
    public void addCategory(Category category)
    {
        context.Category.Add(category);
        context.SaveChanges();

    }
    public List<Restaurant> getRestaurants()
	{
		return context.Restaurant.ToList();
	}
    public Restaurant getRestaurantById(int id)
    {
	    Restaurant? restaurant = context.Restaurant.Find(id);
        return restaurant;
    }
    public void deleteRestaurant(int id)
    {
	    Restaurant restaurant = getRestaurantById(id);
	    Console.Write(restaurant.categories);
	    restaurant.categories.ForEach((category => context.Category.Remove(category)
			    ));
	    context.SaveChanges();
        context.Restaurant.Remove(restaurant);
        context.SaveChanges();
    }
}
