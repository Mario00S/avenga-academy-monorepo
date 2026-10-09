using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaApp.DataAccess.Context;
using PizzaApp.DataAccess.Repositories.Abstractions;
using PizzaApp.DataAccess.Repositories.Implementations;
using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAccess;

public static class DependencyInjection
{
    public const string ConnectionStringName = "PizzaAppDb";

    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
            ?? throw new InvalidOperationException(
                $"Connection string '{ConnectionStringName}' is not configured.");

        services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddIdentityCore<User>(options => options.User.RequireUniqueEmail = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PizzaAppDbContext>();

        //Repositories
        services.AddScoped<IPizzaRepository, PizzaRepository>();

        return services;
    }
}
