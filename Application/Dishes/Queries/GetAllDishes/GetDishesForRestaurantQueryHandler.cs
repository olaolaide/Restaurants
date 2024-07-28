using Application.Dishes.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Dishes.Queries.GetAllDishes;

public class GetDishesForRestaurantQueryHandler(
    ILogger<GetDishesForRestaurantQueryHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetDishesForRestaurantQuery, List<DishDto>>
{
    public async Task<List<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dishes for restaurant {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        var results = mapper.Map<List<DishDto>>(restaurant.Dishes);
        return results;
    }
}