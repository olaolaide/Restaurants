using Domain.Entities;

namespace Domain.Repositories;

public interface IDishesRepository
{
    Task<int> CreateDishAsync(Dish dish);
    Task UpdateDishAsync(Dish dish);
    Task DeleteDishAsync(Dish dish);
}