using Domain.Entities;

namespace Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<List<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetRestaurantById(int id);
}