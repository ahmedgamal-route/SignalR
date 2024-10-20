using Microsoft.EntityFrameworkCore;
using SignalR.MVC.Context;
using SignalR.MVC.Hubs;

namespace SignalR.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ChatDbContext>(o =>
            {
                o.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnectionstring"));
            });

            builder.Services.AddSignalR();

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("default", p =>
                {
                    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("default");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.MapHub<ChatHub>("/chathub");

            app.Run();
        }
    }
}
