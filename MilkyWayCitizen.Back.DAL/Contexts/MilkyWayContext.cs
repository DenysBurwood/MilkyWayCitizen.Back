using Microsoft.EntityFrameworkCore;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Contexts
{
    public class MilkyWayContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<UserArchive> UserArchives { get; set; }

        public MilkyWayContext(DbContextOptions<MilkyWayContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MilkyWayContext).Assembly);
        }
    }
}
