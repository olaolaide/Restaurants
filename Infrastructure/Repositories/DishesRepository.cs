using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class DishesRepository(RestaurantsDbContext context) : IDishesRepository
{
    public async Task<int> CreateDishAsync(Dish dish)
    {
        context.Dishes.Add(dish);
        await context.SaveChangesAsync();
        return dish.Id;
    }

    public async Task UpdateDishAsync(Dish dish)
    {
        context.Dishes.Update(dish);
        await context.SaveChangesAsync();
    }

    public async Task DeleteDishAsync(Dish dish)
    {
        context.Dishes.Remove(dish);
        await context.SaveChangesAsync();
    }

    public async Task DeleteDishesForRestaurantAsync(List<Dish> dishes)
    {
        context.Dishes.RemoveRange(dishes);
        await context.SaveChangesAsync();
    }
}