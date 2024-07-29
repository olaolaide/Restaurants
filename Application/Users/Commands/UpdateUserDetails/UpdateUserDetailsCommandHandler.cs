using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.UpdateUserDetails;

public class UpdateUserDetailsCommandHandler(
    ILogger<UpdateUserDetailsCommandHandler> logger,
    IUserContext userContext,
    IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Updating user details for {UserId}", user!.Id);

        var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken);
        if (dbUser == null)
        {
            throw new NotFoundException(nameof(User), user.Id);
        }

        dbUser.FirstName = request.FirstName;
        dbUser.LastName = request.LastName;
        dbUser.Nationality = request.Nationality;
        dbUser.DateOfBirth = request.DateOfBirth;

        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}