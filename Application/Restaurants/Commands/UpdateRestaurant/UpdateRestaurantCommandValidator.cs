using FluentValidation;

namespace Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(3, 100);
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").Length(3, 200);
    }
}