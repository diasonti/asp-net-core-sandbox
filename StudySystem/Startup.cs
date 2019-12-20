using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudySystem.Data;
using StudySystem.Models;
using StudySystem.Repositories;
using StudySystem.Repositories.Interfaces;
using StudySystem.Services;
using StudySystem.Services.Interfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace StudySystem
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("sqlite")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<AbstractClassRepository, ClassRepository>();
            services.AddScoped<AbstractCourseRepository, CourseRepository>();
            services.AddScoped<AbstractUserAccountRepository, UserAccountRepository>();
            
            services.AddScoped<IClassesService, ClassesService>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<ITasksService, TasksService>();
            services.AddScoped<IUsersService, UsersService>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            InitializeSampleUsers(app);
        }
        
        private void InitializeSampleUsers(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            var roles = new string[] {"ADMIN", "STUDENT"};
           foreach (string role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }


            var user2 = new IdentityUser
            {
                Email = "student@example.com",
                NormalizedEmail = "STUDENT@EXAMPLE.COM",
                UserName = "student",
                NormalizedUserName = "STUDENT",
                PhoneNumber = "+777711111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            
            var user1 = new IdentityUser
            {
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+777711111112",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            var password = new PasswordHasher<IdentityUser>();
            if (!userManager.Users.Any(u => u.UserName == user1.UserName))
            {
                var hashed = password.HashPassword(user1,"secret");
                user1.PasswordHash = hashed;

                userManager.CreateAsync(user1).Wait();
                user1 = userManager.FindByEmailAsync("admin@example.com").Result;
                userManager.AddToRoleAsync(user1, "ADMIN").Wait();
            }
            
            if (!userManager.Users.Any(u => u.UserName == user2.UserName))
            {
                var hashed = password.HashPassword(user2,"secret");
                user2.PasswordHash = hashed;

                userManager.CreateAsync(user2).Wait();
                user2 = userManager.FindByEmailAsync("student@example.com").Result;
                userManager.AddToRoleAsync(user2, "STUDENT").Wait();
            }
            

            context.SaveChangesAsync();
        }
    }
}
