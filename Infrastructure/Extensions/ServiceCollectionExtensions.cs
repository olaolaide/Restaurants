using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Infrastructure.Authorization;
using Infrastructure.Authorization.Requirements;
using Infrastructure.Authorization.Services;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantsDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();


        // Identity
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<RestaurantUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<RestaurantsDbContext>();

        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationality, policy => policy.RequireClaim(AppClaimsType.Nationality))
            .AddPolicy(PolicyNames.AtLeast20, policy => policy.AddRequirements(new MinimumAgeRequirement(20)));

        services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
        services.AddScoped<IRestaurantAuthorizationService, RestaurantAuthorizationService>();
    }
}