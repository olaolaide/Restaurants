using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Dish> Dishes => Set<Dish>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }
}   