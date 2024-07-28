using MediatR;

namespace Application.Dishes.Commands.UpdateDish;

public class UpdateDishCommand : IRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; } = default!;
    public decimal? Price { get; set; }
    public int? KiloCalories { get; set; }
    public int DishId { get; set; }
    public int RestaurantId { get; set; }
    
}