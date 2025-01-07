using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using order.service.domain.Models;

namespace order.service.efcore.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Customer).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.Status).IsRequired();

        builder.OwnsMany(x => x.Items, orderItems =>
        {
            orderItems.HasKey(z => z.Id);
            orderItems.Property(z => z.Id).ValueGeneratedOnAdd();
            orderItems.Property(z => z.ItemId).IsRequired();
            orderItems.Property(z => z.Quantity).IsRequired();
            orderItems.Property(z => z.AddedAt).IsRequired();
            orderItems.OwnsOne(z => z.Item, a =>
            {
                a.ToTable("Items");
                a.HasKey(x => x.Id);
                a.Property(b => b.Name).IsRequired();
                a.Property(b => b.Price).IsRequired();
            });
        });

        builder.OwnsMany(x => x.History, orderStatusHistory =>
        {
            orderStatusHistory.HasKey(z => z.Id);
            orderStatusHistory.Property(z => z.Id).ValueGeneratedOnAdd();
            orderStatusHistory.Property(z => z.Status).IsRequired();
            orderStatusHistory.Property(z => z.CreatedAt).IsRequired();
        });
    }
}
