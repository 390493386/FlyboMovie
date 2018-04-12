using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Dtos
{
    public class OrderNumberSettingDto
    {
        public OrderType Type { get; set; }
        public string Prefix { get; set; }
        public int Seed { get; set; }
    }
}
