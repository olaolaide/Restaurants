using Application.Restaurants.DTOs;
using MediatR;

namespace Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
{
    public int Id { get; init; } = id;
}