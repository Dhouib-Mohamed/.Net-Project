using project_.net.Database;
using project_.net.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public class RestaurantRepository
{
	Context _context;
	public RestaurantRepository()
	{
		_context = Context.getInstance();

    }
	public void addRestaurant(Restaurant restaurant)
	{
		_context.Restaurant.Add(restaurant);
		_context.SaveChanges();
	}
	public void editRestaurant(Restaurant restaurant)
	{
		_context.Restaurant.Update(restaurant);
		_context.SaveChanges();
	}

	public List<Category> getCategories()
	{
		return _context.Category.ToList();
	}
    public void addCategory(Category category)
    {
        _context.Category.Add(category);
        _context.SaveChanges();

    }
    public List<Restaurant> getRestaurants()
	{
		return _context.Restaurant.ToList();
	}
    public Restaurant getRestaurantById(int id)
    {
	    Restaurant restaurant = context.Restaurant.Find(id);
        return restaurant;
    }
    public void deleteRestaurant(int id)
    {
	    Restaurant restaurant = getRestaurantById(id);
	    Console.Write(restaurant.categories);
	    restaurant.categories.ForEach((category => _context.Category.Remove(category)
			    ));
	    _context.SaveChanges();
        _context.Restaurant.Remove(restaurant);
        _context.SaveChanges();
    }
    
}
