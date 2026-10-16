using Microsoft.AspNetCore.Authentication.JwtBearer;
using PizzaApp.Api.OpenApi;
using Scalar.AspNetCore;

namespace PizzaApp.Api.Extensions;

public static class OpenApiDocumentationExtensions
{
    public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi(options => options.AddDocumentTransformer<BearerSecuritySchemeTransformer>());
        return services;
    }

    public static WebApplication MapApiDocs(this WebApplication app)
    {
        app.MapOpenApi().AllowAnonymous();

        app.MapScalarApiReference(options => options
                .WithTitle("PizzaApp API")
                .AddPreferredSecuritySchemes(JwtBearerDefaults.AuthenticationScheme))
            .AllowAnonymous();

        return app;
    }
}
