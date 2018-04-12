using FlyboMovie.Common;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Repository.Implement
{
    public class OrderNumberSettingRepository : RecordRepositoryBase<int, OrderNumberSetting>, IOrderNumberSettingRepository
    {
        public OrderNumberSettingRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
