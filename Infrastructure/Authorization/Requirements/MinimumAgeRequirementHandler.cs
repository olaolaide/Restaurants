using Application.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirementHandler(
    ILogger<MinimumAgeRequirementHandler> logger,
    IUserContext userContext)
    : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        MinimumAgeRequirement requirement)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("Handling requirement {Requirement}", nameof(MinimumAgeRequirement));
        // If user is not authenticated, deny access
        if (currentUser is null)
        {
            logger.LogInformation("Requirement {Requirement} is not met", nameof(MinimumAgeRequirement));
            context.Fail();
        }

        // If user is authenticated but does not have a date of birth, deny access
        if (currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Now))
        {
            logger.LogInformation("Requirement {Requirement} is met", nameof(MinimumAgeRequirement));
            context.Succeed(requirement);
        }
        else
        {
            logger.LogInformation("Requirement {Requirement} is not met", nameof(MinimumAgeRequirement));
            context.Fail();
        }

        return Task.CompletedTask;
    }
}