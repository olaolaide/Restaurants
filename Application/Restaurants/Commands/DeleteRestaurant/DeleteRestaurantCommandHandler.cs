using Domain.Constants;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(
    ILogger<DeleteRestaurantCommand> logger,
    IRestaurantsRepository restaurantsRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService
) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id {RestaurantId}", request.Id);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant is null) throw new NotFoundException(nameof(restaurant), request.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperations.Delete))
        {
            throw  new ForbiddenException();
        }

        await restaurantsRepository.DeleteRestaurant(restaurant);
    }
}