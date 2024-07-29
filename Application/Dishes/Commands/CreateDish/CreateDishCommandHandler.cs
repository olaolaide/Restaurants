using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(
    ILogger<CreateDishCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService,
    IMapper mapper) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating dish {Name}", request.Name);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant is null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperations.Delete))
            throw new ForbiddenException();
        var dish = mapper.Map<Dish>(request);
        var dishId = await dishesRepository.CreateDishAsync(dish);
        return dishId;
    }
}