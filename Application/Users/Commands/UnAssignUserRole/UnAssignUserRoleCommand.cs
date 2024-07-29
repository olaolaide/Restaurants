using MediatR;

namespace Application.Users.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommand : IRequest
{
    public required string UserEmail { get; set; }
    public required string RoleName { get; set; }
}