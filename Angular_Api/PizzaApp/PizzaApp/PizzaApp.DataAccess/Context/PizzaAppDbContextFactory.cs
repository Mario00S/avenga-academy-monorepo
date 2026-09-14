using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PizzaApp.DataAccess.Context;

public class PizzaAppDbContextFactory : IDesignTimeDbContextFactory<PizzaAppDbContext>
{
    private const string ApiUserSecretsId = "5ac44011-1049-4af3-9754-78b7b50a89af";

    public PizzaAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString(DependencyInjection.ConnectionStringName)
            ?? throw new InvalidOperationException(
                $"Connection string '{DependencyInjection.ConnectionStringName}' is not configured. " +
                "Add it to user secrets or appsettings.Development.json on the Api project.");

        var optionsBuilder = new DbContextOptionsBuilder<PizzaAppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new PizzaAppDbContext(optionsBuilder.Options);
    }

    private static IConfiguration BuildConfiguration()
    {
        var apiProjectPath = FindApiProjectDirectory();

        return new ConfigurationBuilder()
            .SetBasePath(apiProjectPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .AddUserSecrets(ApiUserSecretsId)
            .Build();
    }

    private static string FindApiProjectDirectory()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory is not null)
        {
            var apiPath = Path.Combine(directory.FullName, "PizzaApp.Api");
            if (Directory.Exists(apiPath))
            {
                return apiPath;
            }

            directory = directory.Parent;
        }

        throw new InvalidOperationException("Could not find the PizzaApp.Api project directory.");
    }
}
