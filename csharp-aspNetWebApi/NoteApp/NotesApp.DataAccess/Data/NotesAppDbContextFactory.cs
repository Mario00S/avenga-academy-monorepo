using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NotesApp.DataAccess.Data;

public class NotesAppDbContextFactory : IDesignTimeDbContextFactory<NotesAppDbContext>
{
    public NotesAppDbContext CreateDbContext(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string apiPath = Path.GetFullPath(Path.Combine(currentDirectory, "..", "NotesApp"));

        if (!File.Exists(Path.Combine(apiPath, "appsettings.json")))
        {
            apiPath = Path.GetFullPath(Path.Combine(currentDirectory, "NotesApp"));
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(apiPath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        string connectionString = configuration.GetConnectionString("NotesAppDb")
            ?? throw new InvalidOperationException("Connection string 'NotesAppDb' was not found.");

        DbContextOptionsBuilder<NotesAppDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer(connectionString);

        return new NotesAppDbContext(optionsBuilder.Options);
    }
}
