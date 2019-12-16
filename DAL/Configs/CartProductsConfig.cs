using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class CartProductsConfig : IEntityTypeConfiguration<CartProducts>
    {
        public void Configure(EntityTypeBuilder<CartProducts> builder)
        {
            builder.HasKey(b => new {b.UserId, b.ProductId});

            builder.HasOne(c => c.User)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pc => pc.Amount)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}