using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Surname)
                .IsRequired();

            builder.Property(p => p.Address)
                .IsRequired();

            builder.Property(p => p.Password)
                .IsRequired();

            builder.Property(p => p.Role)
                .IsRequired();
        }
    }
}
