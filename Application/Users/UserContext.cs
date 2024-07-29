﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }

        if (!user.Identity.IsAuthenticated || user.Identity is null)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        var nationality = user.Claims.FirstOrDefault(c => c.Type == "nationality")?.Value;
        var dateOfBirthString = user.Claims.FirstOrDefault(c => c.Type == "DateOfBirth")?.Value;
        var dateOfBirth = dateOfBirthString == null
            ? (DateOnly?)null
            : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd", null);
        return new CurrentUser(userId, email, roles, nationality, dateOfBirth);
    }
}