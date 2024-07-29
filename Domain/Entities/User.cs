using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public List<Restaurant> OwnedRestaurants { get; set; } = [];
}