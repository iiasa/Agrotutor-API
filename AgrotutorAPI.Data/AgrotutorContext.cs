using System;
using AgrotutorAPI.Data.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AgrotutorAPI.Data
{
    public class AgrotutorContext:DbContext
    {
        public AgrotutorContext(DbContextOptions <AgrotutorContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Plot> Plots { get; set; }
        public DbSet<Activity> Activities { get; set; }

    }
}
