using BusinessLayer;
using Data_Layer;
using Microsoft.EntityFrameworkCore;

namespace UI_Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TradingDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<TradeEmulationService>();

            // Build the application
            var app = builder.Build();

            // Register the root service provider as a singleton
            var rootServiceProvider = app.Services;

            // Pass the root service provider to the HomeController
            HomeController.SetRootServiceProvider(rootServiceProvider);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
