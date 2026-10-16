using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.Exceptions;

namespace PizzaApp.Services.Extensions;

public static class CurrentUserExtensions
{
    public static void EnsureOwnerOrAdmin(this ICurrentUser currentUser, string ownerId)
    {
        if (currentUser.IsAdmin || currentUser.Id == ownerId)
        {
            return;
        }

        throw new ForbiddenException("You are not authorized to access this resource");
    }
}
