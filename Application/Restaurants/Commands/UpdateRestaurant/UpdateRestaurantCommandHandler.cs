using AutoMapper;
using Domain.Constants;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(
    ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id {}", request.Id);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant == null) throw new NotFoundException(nameof(restaurant), request.Id.ToString());
        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperations.Update)) throw  new ForbiddenException();
        
        mapper.Map(request, restaurant);
        await restaurantsRepository.UpdateRestaurant(restaurant);
    }
}