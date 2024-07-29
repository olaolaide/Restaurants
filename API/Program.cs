using API.Extensions;
using API.Middleware;
using Application.Extensions;
using Domain.Entities;
using Infrastructure.Extensions;
using Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Create a scope to resolve services
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGroup("/api/identity").WithTags("Identity").MapIdentityApi<User>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();