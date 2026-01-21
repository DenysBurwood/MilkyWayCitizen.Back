
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Configs
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User_");
            builder.HasKey(u => u.Id).HasName("PK_User");

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(32);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(60);
            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired();
            //builder.Property(u => u.PublishedNews);

            builder.HasMany(u => u.PublishedNews).WithOne(n => n.Author);
        }
    }
}
