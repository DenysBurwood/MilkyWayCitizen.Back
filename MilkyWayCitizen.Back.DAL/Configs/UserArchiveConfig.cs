
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Configs
{

    public class UserArchiveConfig:IEntityTypeConfiguration<UserArchive>
    {
        public void Configure(EntityTypeBuilder<UserArchive> builder)
        {
            builder.ToTable("UserArchive");
            builder.HasKey(u => u.Id).HasName("PK_UserArchive");
            builder.Property(u => u.Id).UseIdentityColumn();

            //builder.Property(u => u.UserName).IsRequired().HasMaxLength(32);
            //builder.Property(u => u.FirstName).IsRequired().HasMaxLength(60);
            //builder.Property(u => u.LastName).IsRequired().HasMaxLength(60);
            //builder.HasIndex(u => u.Email);
            //builder.Property(u => u.BirthDate).IsRequired();
        }
    }
}
