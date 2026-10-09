using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaApp.Mappers;

public static class DependencyInjection
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.RequireExplicitMapping = true;

        config.Scan(typeof(DependencyInjection).Assembly);

        config.Compile();

        services.AddSingleton(config);

        services.AddScoped<IMapper, ServiceMapper>();

        //services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;
    }
}
