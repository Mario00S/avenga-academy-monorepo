using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using PizzaApp.Domain.Constants;
using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.Exceptions;

namespace PizzaApp.Api.Security;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? Principal => _httpContextAccessor.HttpContext?.User;

    public string Id => Principal?.FindFirstValue(JwtRegisteredClaimNames.Sub)
        ?? throw new UnauthorizedException("You are not logged in");

    public bool IsAdmin => Principal?.IsInRole(Roles.Admin) ?? false;
}
