using FlyboMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyboMovie.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(2048);
            builder.Property(m => m.PosterLink).HasMaxLength(1024);
            builder.Property(m => m.MovieLink1).HasMaxLength(1024);
            builder.Property(m => m.MovieLink2).HasMaxLength(1024);
            builder.Property(m => m.MovieLink3).HasMaxLength(1024);
            builder.Property(m => m.Price).IsRequired();
        }
    }
}
