using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Models
{
    public class OrderNumberSetting : RecordBase<int>
    {
        public OrderType Type { get; set; }
        public string Prefix { get; set; }
        public int Seed { get; set; }
    }
}
