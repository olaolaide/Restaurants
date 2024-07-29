using Infrastructure.Persistence;


namespace Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
    {
        public Task Seed()
        {
            return Task.CompletedTask;
        }
    }
}