using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(p => p.Rating)
                .HasDefaultValue(0);

            builder.Property(p => p.Text)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
