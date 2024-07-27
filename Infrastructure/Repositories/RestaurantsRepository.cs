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
        var restaurant =  await context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
}