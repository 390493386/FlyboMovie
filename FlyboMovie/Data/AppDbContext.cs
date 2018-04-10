using FlyboMovie.Data.Configuration;
using FlyboMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace FlyboMovie.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<BuyOrder> BuyOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new BuyOrderConfiguration());
        }
    }
}
