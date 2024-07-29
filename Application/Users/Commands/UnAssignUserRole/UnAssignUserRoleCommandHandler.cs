using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommandHandler(
    ILogger<UnAssignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnAssignUserRoleCommand>
{
    public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("UnAssignUserRoleCommandHandler called");
        var user = await userManager.FindByEmailAsync(request.UserEmail);
        var role = await roleManager.FindByNameAsync(request.RoleName);
        if (user == null || role == null)
        {
            throw new NotFoundException(nameof(User), request.UserEmail);
        }

        var result = await userManager.RemoveFromRoleAsync(user, role.Name!);
        if (!result.Succeeded)
        {
            throw new NotFoundException(nameof(User), request.UserEmail);
        }
    }
}