using BaiTapThucHanhWeek4.Models;
using BaiTapThucHanhWeek4.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucHanhWeek4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("QlbanVaLiContext");
            builder.Services.AddDbContext<QlbanVaLiContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();
            builder.Services.AddSession();


            //// Identity Platform
            //builder.Services.AddIdentityCore<TUser>();
            //builder.Services.AddAuthentication().AddCookie("MyAuth", options => {
            //    options.Cookie.Name = "access_token";
            //    options.Cookie.SameSite = SameSiteMode.Strict;
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(90);
            //});

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

            //app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Access}/{action=Login}/{id?}");

            app.Run();
        }
    }
}