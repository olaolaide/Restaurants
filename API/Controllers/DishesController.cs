using Application.Dishes.Commands.CreateDish;
using Application.Dishes.Commands.DeleteDish;
using Application.Dishes.Commands.DeleteDishes;
using Application.Dishes.Commands.UpdateDish;
using Application.Dishes.DTOs;
using Application.Dishes.Queries.GetAllDishes;
using Application.Dishes.Queries.GetDish;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/restaurant/{restaurantId:int}/dishes")]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<DishDto>>> GetDishes([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId:int}")]
    public async Task<ActionResult<DishDto>> GetDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
        return Ok(dish);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var dishId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetDish), new { restaurantId, dishId }, command);
    }

    [HttpPatch("{dishId:int}")]
    public async Task<IActionResult> UpdateDish(int restaurantId, int dishId, [FromBody] UpdateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        command.DishId = dishId;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{dishId:int}")]
    public async Task<IActionResult> DeleteDish([FromRoute] int restaurantId, int dishId)
    {
        await mediator.Send(new DeleteDishForRestaurantCommand(restaurantId, dishId));
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDishes([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));
        return NoContent();
    }
}