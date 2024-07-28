using Application.Restaurants.Commands.CreateRestaurant;
using Application.Restaurants.Commands.DeleteRestaurant;
using Application.Restaurants.Commands.UpdateRestaurant;
using Application.Restaurants.DTOs;
using Application.Restaurants.Queries.GetAllRestaurants;
using Application.Restaurants.Queries.GetRestaurantById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RestaurantDto>>> GetRestaurants()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RestaurantDto?>> GetRestaurant([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<ActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetRestaurant), new { id }, null);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRestaurant([FromRoute] int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }
}