using AgrotutorAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgrotutorAPI.Data.Postgresql
{
    public class AgrotutorContext : DbContext
    {
        public AgrotutorContext(DbContextOptions<AgrotutorContext> options) : base(options)
        {
       
        }

        public DbSet<Plot> Plots { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DelineationPosition> Delineations { get; set; }

        public DbSet<MediaItem> MediaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plot>().OwnsOne(s => s.Position);
            modelBuilder.Entity<DelineationPosition>().OwnsOne(s => s.Position);
            modelBuilder.Entity<MediaItem>().Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
