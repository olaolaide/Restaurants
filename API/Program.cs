using Application.Extensions;
using Infrastructure.Extensions;
using Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();


app.UseAuthorization();
app.MapControllers();


app.Run();