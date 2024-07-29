using Application.Users.Commands;
using Application.Users.Commands.AssignUserRole;
using Application.Users.Commands.UnAssignUserRole;
using Application.Users.Commands.UpdateUserDetails;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AddUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> RemoveUserRole(UnAssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    
}