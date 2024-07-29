using Domain.Constants;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Dishes.Commands.DeleteDishes;

public class DeleteDishesForRestaurantCommandHandler(
    ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IDishesRepository dishesRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteDishesForRestaurantCommand>
{
    public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting dishes for restaurant {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperations.Delete))
            throw new ForbiddenException();
        await dishesRepository.DeleteDishesForRestaurantAsync(restaurant.Dishes);
    }
}