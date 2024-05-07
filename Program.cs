
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCLab.Models;
using MVCLab.Repository;

namespace MVCLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddScoped<IinstructorRepository, instructorRepository>();
            builder.Services.AddScoped<IdepartmentRepository,departmentRepository>();
            builder.Services.AddScoped<IcourseRepository,courseRepository>();


            builder.Services.AddDbContext<context>(Options => { 
                Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
