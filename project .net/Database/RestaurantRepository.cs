﻿using project_.net.Database;
using project_.net.Models;
using System;

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
    public Restaurant getRestaurantByid(int id)
    {
       Restaurant restaurant = (Restaurant)context.Restaurant.Where(r => r.ID == id);
        return (restaurant);
    }
    public void deleteRestaurant(int id)
    {
        Restaurant restaurant = getRestaurantByid(id);
        context.Restaurant.Remove(restaurant);
        context.SaveChanges();
    }
}
