using FluentValidation;

namespace Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(3, 100);
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").Length(3, 200);
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required").Length(3, 50);

        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot be longer than 500 characters");
        RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Invalid email address");
    }
}