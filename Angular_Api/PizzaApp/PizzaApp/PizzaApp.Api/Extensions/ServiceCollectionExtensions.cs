using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Api.ExceptionHandling;
using PizzaApp.Api.Security;
using PizzaApp.Services.Abstractions;

namespace PizzaApp.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.InvalidModelStateResponseFactory = CreateValidationErrorResponse;
            });

        services.AddOpenApiDocumentation();
        services.AddJwtAuthentication(configuration);
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUser, CurrentUser>();

        return services;
    }

    private static BadRequestObjectResult CreateValidationErrorResponse(ActionContext context)
    {
        var errors = context.ModelState.Values
            .SelectMany(entry => entry.Errors)
            .Select(error => error.ErrorMessage)
            .Where(message => !string.IsNullOrWhiteSpace(message))
            .ToList();

        return new BadRequestObjectResult(new
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = "Validation failed.",
            Errors = errors,
            TraceId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier,
        });
    }
}
