using Application.Restaurants.DTOs;
using MediatR;

namespace Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<List<RestaurantDto>>;