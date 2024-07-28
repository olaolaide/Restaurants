using FluentValidation;

namespace Application.Dishes.Commands.UpdateDish;

public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
{
    public UpdateDishCommandValidator()
    {
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");
        RuleFor(x => x.KiloCalories).GreaterThanOrEqualTo(0)
            .WithMessage("KiloCalories must be greater than or equal to 0");
    }
}