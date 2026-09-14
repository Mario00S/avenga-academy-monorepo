using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Domain.Constants;

namespace PizzaApp.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public const string AdminRoleId = "00000000-0000-0000-0000-000000000002"; // to be changed to a real GUID in production
    public const string CustomerRoleId = "00000000-0000-0000-0000-000000000003"; // to be changed to a real GUID in production

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = AdminRoleId,
                Name = Roles.Admin,
                NormalizedName = Roles.Admin.ToUpperInvariant(),
                ConcurrencyStamp = "guid generated",
            },
            new IdentityRole
            {
                Id = CustomerRoleId,
                Name = Roles.Customer,
                NormalizedName = Roles.Customer.ToUpperInvariant(),
                ConcurrencyStamp = "guid generated",
            }
        );
    }
}
