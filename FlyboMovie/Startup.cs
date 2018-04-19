using AutoMapper;
using FlyboMovie.Common;
using FlyboMovie.Data;
using FlyboMovie.Data.Repository;
using FlyboMovie.Data.Repository.Implement;
using FlyboMovie.Filters;
using FlyboMovie.Services;
using FlyboMovie.Services.Implement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlyboMovie
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
            services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

            services.AddAutoMapper();
            services.AddMvc()
                .AddRazorPagesOptions(options => 
                {
                    options.Conventions.ConfigureFilter(new LoginFilter());
                });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/Login";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
            });

            services.AddScoped<IDbFactory, AppDbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region repostories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IBuyOrderRepository, BuyOrderRepository>();
            services.AddTransient<IOrderNumberSettingRepository, OrderNumberSettingRepository>();
            #endregion

            #region services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IBuyOrderService, BuyOrderService>();
            services.AddScoped<IOrderNumberSettingService, OrderNumberSettingService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            MappersRegister.RegistMappers();
        }
    }
}
