using Application.Dishes.DTOs;
using MediatR;

namespace Application.Dishes.Queries.GetAllDishes;

public class GetDishesForRestaurantQuery(int restaurantId) : IRequest<List<DishDto>>
{
    public int RestaurantId { get; } = restaurantId;
}