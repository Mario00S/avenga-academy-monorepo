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
            PasswordHash = "AQAAAAIAAYagAAAAEORMNJTSPwqrmb2GKtm5oxli8mkCddIShGuomTmTzpYUfNBuyB9YyZyhymbYQOXTMA==",

            SecurityStamp = "ea93155b-08c2-4539-a6d5-e922d27173e3",
            ConcurrencyStamp = "d476b4e7-13dc-42c4-a6a2-0c1c5e8897be"

        });
    }
}
