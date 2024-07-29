using System.Security.Claims;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authorization;

public class RestaurantUserClaimsPrincipalFactory(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> options)
    : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var claimIdentity = await GenerateClaimsAsync(user);
        if (user.Nationality != null)
        {
            claimIdentity.AddClaim(new Claim(AppClaimsType.Nationality, user.Nationality));
        }

        if (user.DateOfBirth != null)
        {
            claimIdentity.AddClaim(new Claim(AppClaimsType.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
        }

        return new ClaimsPrincipal(claimIdentity);
    }
}