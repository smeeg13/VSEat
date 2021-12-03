using BLL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
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
            //ADD FOLLOWING LINE FOR EACH I.... CLASSES WE HAVE
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserDB, UserDB>();
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IRestaurantDB, RestaurantDB>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IOrderDetailDB, OrderDetailDB>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDB, OrderDB>();
            services.AddScoped<ICategoryDB, CategoryDB>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IDelivererDB, DelivererDB>();
            services.AddScoped<IDelivererManager, DelivererManager>();
            services.AddScoped<ILocationDB, LocationDB>();
            services.AddScoped<ILocationManager, LocationManager>();
            services.AddScoped<IMenuManager, MenuManager>();
            services.AddScoped<IMenuDB, MenuDB>();


            services.AddSession();
            services.AddControllersWithViews();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
