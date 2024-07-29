﻿using MediatR;

namespace Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public required string UserEmail { get; set; }
    public required string RoleName { get; set; }
}