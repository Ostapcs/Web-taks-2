using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class OrderConfig: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.DeliveryOpt)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
