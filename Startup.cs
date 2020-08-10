﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RecipeSite.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RecipeSite
{
    public class Startup

    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config) =>
            Configuration = config;



        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration["Data:SiteRecipes:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connection));
            

            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
           
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });

            SeedData.EnsurePopulated(app);

        }
    }
}
