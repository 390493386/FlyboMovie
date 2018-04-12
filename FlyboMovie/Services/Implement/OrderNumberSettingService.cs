using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Services.Implement
{
    public class OrderNumberSettingService : DataServiceBase<OrderNumberSetting, OrderNumberSettingDto, int>, IOrderNumberSettingService
    {
        public OrderNumberSettingService(IUnitOfWork unitOfWork, IOrderNumberSettingRepository orderNumberSettingRepository)
            : base(orderNumberSettingRepository, unitOfWork)
        {
        }

        public string GenerateOrderNumber(OrderType orderType)
        {
            var setting = Repository.QueryWithTracking(x => x.Type == orderType).FirstOrDefault();
            if (setting == null)
            {
                return null;
            }
            var seed = setting.Seed;
            setting.Seed = (setting.Seed + 1) % 999999;
            UnitOfWork.SaveChanges();
            return setting.Prefix + DateTime.Now.ToString("yyMMdd") + seed.ToString("D6");
        }
    }
}
