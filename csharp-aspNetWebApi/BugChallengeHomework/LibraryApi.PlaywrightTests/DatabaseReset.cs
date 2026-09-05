using LibraryApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.PlaywrightTests;

/// <summary>
/// Runs once before any Playwright tests in this assembly.
/// Stop LibraryApi before uncommenting the reset (open connections block DROP DATABASE).
/// After a reset, start the API again so it sees the reseeded LocalDB.
/// </summary>
[SetUpFixture]
public class DatabaseReset
{
    private const string ConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True";

    [OneTimeSetUp]
    public async Task ResetDatabaseIfEnabled()
    {
        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        await using var context = new LibraryDbContext(options);

        // Uncomment the next two lines to drop LibraryDb and re-apply migrations + HasData seed.
        // await context.Database.EnsureDeletedAsync();
        // await context.Database.MigrateAsync();
    }
}
