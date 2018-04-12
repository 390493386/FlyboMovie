using FlyboMovie.Common;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Services
{
    public interface IBuyOrderService: IDataService<BuyOrder, BuyOrderDto, int>
    {
        BuyOrderDto Create(BuyOrderDto buyOrder);
    }
}
