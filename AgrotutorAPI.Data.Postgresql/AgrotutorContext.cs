using System;
using AgrotutorAPI.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AgrotutorAPI.Data.Postgresql
{
    public class AgrotutorContext : DbContext
    {
        public AgrotutorContext(DbContextOptions<AgrotutorContext> options) : base(options)
        {
            // Database.Migrate();
        }

        public DbSet<Plot> Plots { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Delineation> Delineations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plot>().OwnsOne(s => s.Position);
            modelBuilder.Entity<Delineation>().OwnsOne(s => s.Position);
        }
    }
}
