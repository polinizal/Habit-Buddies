using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Habit_Buddies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddTransient<DataSeeder>(); //tutorial

            

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.UseLazyLoadingProxies();
                }
              );

            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            //using (var scope =
            //  app.Services.CreateScope())
            //{
            //    using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
            //    {
            //        context.Database.EnsureCreated();

            //    }
            //}
            //if (args.Length == 1 && args[0].ToLower() == "seeddata")
            
            SeedData(app);

            //Seed Data
            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<DataSeeder>();
                    service.Seed();
                    
                }
            }


            app.Run();
        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Add identity
        //    services.AddIdentity<IdentityUser, IdentityRole>()
        //            .AddEntityFrameworkStores<ApplicationDbContext>()
        //            .AddDefaultTokenProviders();

        //    // Add authentication
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //    })
        //    .AddCookie(options =>
        //    {
        //        options.LoginPath = "/Account/Login";
        //        options.LogoutPath = "/Account/Logout";
        //        options.AccessDeniedPath = "/Account/AccessDenied";
        //    });

        //    // Add MVC
        //    services.AddControllersWithViews();
        //}
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    // Use authentication
        //    app.UseAuthentication();

        //    // Use MVC
        //    app.UseRouting();
        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}

    }
}