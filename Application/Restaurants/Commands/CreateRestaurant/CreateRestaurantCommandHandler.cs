using Application.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(
    ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IUserContext context,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = context.GetCurrentUser();
        if (currentUser == null)
        {
            throw new UnauthorizedAccessException();
        }

        logger.LogInformation($"{currentUser.Email} is trying to create a restaurant with name {request.Name}");
        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = currentUser.Id;
        var id = await restaurantsRepository.CreateRestaurant(restaurant);
        return id;
    }
}