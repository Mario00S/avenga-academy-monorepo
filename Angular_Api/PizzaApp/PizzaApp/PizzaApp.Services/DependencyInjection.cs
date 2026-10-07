using Microsoft.Extensions.DependencyInjection;
using PizzaApp.Services.Abstractions;
using PizzaApp.Services.Implementations;

namespace PizzaApp.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //services.AddScoped<IPizzaService, PizzaService>();
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
