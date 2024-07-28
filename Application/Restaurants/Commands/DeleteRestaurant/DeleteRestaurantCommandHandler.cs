using AutoMapper;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(
    ILogger<DeleteRestaurantCommand> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id {RestaurantId}", request.Id);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant is null) throw new NotFoundException(nameof(restaurant), request.Id.ToString());
        await restaurantsRepository.DeleteRestaurant(restaurant);
    }
}