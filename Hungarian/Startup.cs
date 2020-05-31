using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Hungarian.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hungarian.Interfaces;
using Hungarian.Repositories;
using Hungarian.Models.Dishes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Hungarian
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<RoleManager<IdentityRole>>();
            //services.AddScoped<SignInManager<IdentityUser>>();
                //(options => options.SignIn.RequireConfirmedAccount = true);

            //services.AddIdentityCore<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
          
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>(); 
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthorization(options =>
            {
                options.AddPolicy
                ("Public",
                builder =>
                builder.RequireRole("Customer","Admin"));
                options.AddPolicy
                ("Private",
                builder =>
                builder.RequireRole("Admin"));
                options.AddPolicy
                ("Admin",
                builder =>
                builder.RequireRole("Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            
            app.UseStatusCodePages();
         
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthentication();
            app.UseAuthorization();
           
                app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "menudetails",
                      pattern: "Menu/Details/{menuId?}",
                      defaults: new { Controller = "Menu", action = "Details" });

                endpoints.MapControllerRoute(
                    name: "categoryfilter",
                    pattern: "Menu/{action}/{category?}",
                    defaults: new { Controller = "Menu", action = "List" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            DbInitializer.Seed(serviceProvider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
