using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RestaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
{
    public async Task<List<Restaurant>> GetAllRestaurants()
    {
        var restaurants = await context.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        var restaurant = await context.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }

    public async Task<int> CreateRestaurant(Restaurant restaurant)
    {
        context.Restaurants.Add(restaurant);
        await context.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteRestaurant(Restaurant restaurant)
    {
        context.Restaurants.Remove(restaurant);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRestaurant(Restaurant restaurant)
    {
        context.Restaurants.Update(restaurant);
        await context.SaveChangesAsync();
    }
}