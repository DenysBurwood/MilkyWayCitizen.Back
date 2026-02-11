using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Configs
{
    public class ErrorConfig:IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("Errors").HasKey(n => n.Id).HasName("PK_Errors");

            builder.Property(e => e.Message).IsRequired();
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.TimeError).IsRequired();
        }
    }
}
