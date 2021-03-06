﻿
using AgrotutorAPI.Data.Contract;
using AgrotutorAPI.Data.Postgresql;
using AgrotutorAPI.Data.Postgresql.Repositories;
using AgrotutorAPI.Domain;
using AgrotutorAPI.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgrotutorAPI.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AgrotutorContext>(o =>
                o.UseNpgsql(Configuration.GetConnectionString("AgrotutorApiDatabase")));

            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
            Mapper.Initialize(m =>
            {
                m.AddProfile(new AutoMapperPlotProfile());
            });
            UpdateDatabase(app);
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AgrotutorContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}