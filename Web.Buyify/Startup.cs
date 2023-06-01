using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Buyify.Models;

namespace Web.Buyify
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(_configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Pages";
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "Views/Cart/Panier/{id?}",
                    defaults: new { controller = "Cart", action = "AddToCart" });

                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "Product/Details/{id}",
                    defaults: new { controller = "Product", action = "Details" });

                endpoints.MapControllerRoute(
                    name: "newsletterDialog",
                    pattern: "newsletter/dialog",
                    defaults: new { controller = "YourControllerName", action = "NewsletterDialog" });

                endpoints.MapRazorPages();
            });
        }
    }
}
