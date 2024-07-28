using Domain.Entities;

namespace Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<List<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetRestaurantById(int id);
    Task<int> CreateRestaurant(Restaurant restaurant);

    Task DeleteRestaurant(Restaurant restaurant);
    Task UpdateRestaurant(Restaurant restaurant);
}