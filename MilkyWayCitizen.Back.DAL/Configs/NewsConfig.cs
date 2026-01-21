
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Configs
{
    public class NewsConfig:IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News").HasKey(n => n.Id).HasName("PK_News");

            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Description).IsRequired();
            builder.Property(n => n.Text).IsRequired();
            builder.Property(n => n.UserId).IsRequired();
            //builder.Property(n => n.Author).IsRequired();
            builder.Property(n => n.Pictures);
            builder.Property(n => n.PublishTime).IsRequired();
            builder.Property(n => n.Tags).IsRequired();

            builder.HasOne(n => n.Author).WithMany(u => u.PublishedNews).HasForeignKey(n => n.UserId);
        }
    }
}
