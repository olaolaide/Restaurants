using Domain.Entities;

namespace Application.Restaurants;

public interface IRestaurantsService
{
    Task<List<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetRestaurantById(int id);
}