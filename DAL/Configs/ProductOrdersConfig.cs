using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class ProductOrdersConfig : IEntityTypeConfiguration<ProductOrders>
    {
        public void Configure(EntityTypeBuilder<ProductOrders> builder)
        {
            builder.HasKey(b => new {b.OrderId, b.ProductId});

            builder.HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductId);

            builder.HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);
        }
    }
}
