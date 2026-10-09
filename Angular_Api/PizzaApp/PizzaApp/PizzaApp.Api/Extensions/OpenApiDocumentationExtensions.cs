namespace PizzaApp.Api.Extensions;

public static class OpenApiDocumentationExtensions
{
    public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi();
        return services;
    }
}
