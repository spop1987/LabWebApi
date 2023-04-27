using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabDotNet.Models.Entities.TypeConfig
{
    public class UserTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.FirstName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.LastName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.Password).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.UserType).HasColumnType("varchar(10)");
            builder.Property(u => u.CreateDate).HasColumnType("dateTime");
            builder.Property(u => u.UpdateDate).HasColumnType("dateTime");
        }
    }
}