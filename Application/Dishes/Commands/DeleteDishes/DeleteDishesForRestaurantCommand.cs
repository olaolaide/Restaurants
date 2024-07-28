using MediatR;

namespace Application.Dishes.Commands.DeleteDishes;

public class DeleteDishesForRestaurantCommand(int restaurantId) : IRequest
{
    public int RestaurantId { get; set; } = restaurantId;
}