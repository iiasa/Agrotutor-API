using System;
using AgrotutorAPI.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AgrotutorAPI.Data.Postgresql
{
    public class AgrotutorContext:DbContext
    {
        public AgrotutorContext(DbContextOptions <AgrotutorContext> options) : base(options)
        {
          //  Database.Migrate();
        }

        public DbSet<Plot> Plots { get; set; }
        public DbSet<Activity> Activities { get; set; }

    }
}
