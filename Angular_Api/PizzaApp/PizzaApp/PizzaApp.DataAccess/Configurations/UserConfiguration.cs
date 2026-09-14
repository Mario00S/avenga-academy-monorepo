using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public const string AdminUserId = "00000000-0000-0000-0000-000000000001";
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User
        {
            Id = AdminUserId,

            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@pizzaapp.local",
            NormalizedEmail = "ADMIN@PIZZAAPP.LOCAL",

            // Password: Admin123!
            PasswordHash = "AQAAAAEAACcQAAAAEJ0Z1k5F6",

            SecurityStamp = "guid generated",
            ConcurrencyStamp = "guid generated"

        });
    }
}
