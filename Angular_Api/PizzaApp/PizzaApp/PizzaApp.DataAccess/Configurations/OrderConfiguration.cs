using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAccess.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(order => order.AddressTo)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(order => order.Description)
            .HasMaxLength(500);

        builder.Property(order => order.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        //Relationships
        builder.HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Cascade);  

        builder.HasMany(order => order.Pizzas)
            .WithOne(pizza => pizza.Order)
            .HasForeignKey(pizza => pizza.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
