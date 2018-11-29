using AutoMapper;
using FlyboMovie.Common;
using FlyboMovie.Data;
using FlyboMovie.Data.Repository;
using FlyboMovie.Data.Repository.Implement;
using FlyboMovie.Filters;
using FlyboMovie.Models;
using FlyboMovie.Services;
using FlyboMovie.Services.Implement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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

            InitDatabse(app);
        }

        private void InitDatabse(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();

                if (!dbContext.Users.Any())
                {
                    var adminUser = new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "zhanhui",
                        Account="admin",
                        Password = "123456abc",
                        Type = UserType.Registered,
                        Points = 100,
                        RecordCreatedTime = DateTime.Now,
                        RecordCreatedUser = -1,
                    };
                    var adminRole = new Role()
                    {
                        Name = "Admin",
                        RecordCreatedTime = DateTime.Now,
                        RecordCreatedUser = -1,
                    };
                    dbContext.Users.Add(adminUser);
                    dbContext.Roles.Add(adminRole);
                    dbContext.SaveChanges();
                    dbContext.UserRoles.Add(new UserRole
                    {
                        UserId = adminUser.Id,
                        RoleId = adminRole.Id,
                    });
                    dbContext.OrderNumberSettings.Add(new OrderNumberSetting
                    {
                        Type = OrderType.Movie,
                        Prefix = "MV",
                        Seed = 1,
                        RecordCreatedTime = DateTime.Now,
                        RecordCreatedUser = -1,
                    });
                    dbContext.OrderNumberSettings.Add(new OrderNumberSetting
                    {
                        Type = OrderType.BuyOrder,
                        Prefix = "BO",
                        Seed = 1,
                        RecordCreatedTime = DateTime.Now,
                        RecordCreatedUser = -1,
                    });
                    dbContext.SaveChanges();
                }

            }
        }
    }
}
