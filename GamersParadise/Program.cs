//using GamersParadise.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GamersParadise.Data;
using GamersParadise.Areas.Identity.Data;

namespace GamersParadise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("GamersParadiseContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<GamersParadiseContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<GamersParadiseUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<GamersParadiseContext>();
           
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

           
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}