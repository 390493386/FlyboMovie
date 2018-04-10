using FlyboMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyboMovie.Data.Configuration
{
    public class BuyOrderConfiguration : IEntityTypeConfiguration<BuyOrder>
    {
        public void Configure(EntityTypeBuilder<BuyOrder> builder)
        {
            builder.Property(b => b.OrderNumber).IsRequired().HasMaxLength(30);
            builder.Property(b => b.UserId).HasMaxLength(50);
            builder.Property(b => b.ValidationCode).HasMaxLength(10);
        }
    }
}
