using Application.Users;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Authorization.Services;

public class RestaurantAuthorizationService(UserContext userContext, ILogger<RestaurantAuthorizationService> logger)
    : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurant restaurant, ResourceOperations resourceOperations)
    {
        var user = userContext.GetCurrentUser();
        if (user == null)
        {
            logger.LogWarning("An unauthenticated user attempted to access a protected restaurant {RestaurantId}",
                restaurant.Id);
            return false;
        }

        logger.LogWarning("Authorizing User {UserEmail} to {Operation} for restaurant {RestaurantName }", user.Email,
            resourceOperations, restaurant.Name);

        switch (resourceOperations)
        {
            case ResourceOperations.Read or ResourceOperations.Create:
                logger.LogInformation("User {UserEmail} is authorized to {Operation} for restaurant {RestaurantName }",
                    user.Email, resourceOperations, restaurant.Name);
                return true;
            case ResourceOperations.Delete when user.IsInRole(UserRoles.Admin):
                logger.LogInformation("User {UserEmail} is authorized to {Operation} for restaurant {RestaurantName }",
                    user.Email, resourceOperations, restaurant.Name);
                return true;
            case ResourceOperations.Delete or ResourceOperations.Update when
                user.Id == restaurant.OwnerId:
                logger.LogInformation("User {UserEmail} is authorized to {Operation} for restaurant {RestaurantName }",
                    user.Email, resourceOperations, restaurant.Name);
                return true;
            default:
                logger.LogWarning("User {UserEmail} is not authorized to {Operation} for restaurant {RestaurantName }",
                    user.Email, resourceOperations, restaurant.Name);
                return false;
        }
    }
}
