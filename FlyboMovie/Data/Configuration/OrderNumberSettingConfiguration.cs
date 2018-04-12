using FlyboMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Configuration
{
    public class OrderNumberSettingConfiguration : IEntityTypeConfiguration<OrderNumberSetting>
    {
        public void Configure(EntityTypeBuilder<OrderNumberSetting> builder)
        {
            builder.Property(x => x.Prefix).HasMaxLength(10);
        }
    }
}
