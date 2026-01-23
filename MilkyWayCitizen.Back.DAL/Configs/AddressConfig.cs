
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Configs
{
    public class AddressConfig:IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address_").HasKey(a => a.ID).HasName("PK_Address");
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.StreetName).IsRequired();
            builder.Property(a => a.StreetNumber).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.Contry).IsRequired();

            builder.HasOne(a => a.User).WithOne(u => u.Address).HasForeignKey<Address>();
        }
    }
}
