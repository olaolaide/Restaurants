﻿using MediatR;

namespace Application.Users.Commands;

public class UpdateUserDetailsCommand : IRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth  { get; set; }
    public string? Nationality { get; set; }
}