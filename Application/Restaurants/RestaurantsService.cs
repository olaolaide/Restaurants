using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Restaurants;

public class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<List<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllRestaurants();
        return restaurants;
    }

    public Task<Restaurant?> GetRestaurantById(int id)
    {
        logger.LogInformation($"Getting restaurant with id {id}");
        return restaurantsRepository.GetRestaurantById(id);
    }
}