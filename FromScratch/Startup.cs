using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromScratch.Models;
using Microsoft.AspNetCore.Identity;
using FromScratch.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Repositories;
using Services.Contracts;
using FS_BAL.Interfaces;
using FS_BAL.Operations;
using AutoMapper;
using FS_BAL.Mapping;

namespace FromScratch
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
            services.AddControllersWithViews();
            services.AddDbContext<FSContext> (options =>
                options.UseSqlServer(Configuration.GetConnectionString("DWConnectionString")));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<FSContext>();

            services.AddScoped<IUOW,UOW>();
            services.AddScoped<ICatalogOperations, CatalogOperations>();
            services.AddScoped<IAccountOperations, AccountOperations>();
            services.AddScoped<IUserOperations, UserOperations>();
            services.AddAutoMapper(typeof(MapProfile).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Welcome}/{action=Index}/{id?}");
            });
        }
    }
}
