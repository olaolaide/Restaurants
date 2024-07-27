using Application.Restaurants;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant([FromRoute]int id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
}