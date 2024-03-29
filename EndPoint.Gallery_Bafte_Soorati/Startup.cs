using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Application.Services.Categories.Commands;
using Gallery_Bafte_Soorati.Application.Services.Categories.Queriess.GetCategory;
using Gallery_Bafte_Soorati.Application.Services.HomePages.AddHomePages;
using Gallery_Bafte_Soorati.Application.Services.HomePages.AddSlider;
using Gallery_Bafte_Soorati.Application.Services.HomePages.Queries;
using Gallery_Bafte_Soorati.Application.Services.Users.Commands.AddUsers;
using Gallery_Bafte_Soorati.Application.Services.Users.MediatR.Command;
using Gallery_Bafte_Soorati.Application.Services.Users.Queries.GetUsers;
using Gallery_Bafte_Soorati.Common;
using Gallery_Bafte_Soorati.Presistance.DataBaseContext;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace EndPoint.Gallery_Bafte_Soorati
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

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/Signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Authentication/Signin");
            });

            services.AddScoped<IStorage, Storage>();
            services.AddScoped<IGetSliderService, GetSliderService>();
            services.AddScoped<IAddHomePageService, AddHomePageService>();
            services.AddScoped<IAddSliderService, AddSliderService>();
            services.AddScoped<IGetHomePageSevice, GetHomePageSevice>();
            services.AddScoped<IAddCategoryService, AddCategoryService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();
            //services.AddScoped<IAddUserService, AddUserService>();
            services.AddMediatR(typeof(AddUser).GetTypeInfo().Assembly);
            services.AddScoped<IGetUserService, GetUserService>();

            string StrConnection = "Data Source =.;Initial Catalog=DbGallerySoorati; Integrated Security=True";
            services.AddEntityFrameworkSqlServer().AddDbContext<Storage>(p => p.UseSqlServer(StrConnection));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
