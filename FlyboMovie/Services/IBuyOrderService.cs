using FlyboMovie.Common;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using System.Collections.Generic;

namespace FlyboMovie.Services
{
    public interface IBuyOrderService: IDataService<BuyOrder, BuyOrderDto, int>
    {
        BuyOrderDto Create(BuyOrderDto buyOrder);
        List<BuyOrderLiteDto> SearchCreatedOrders(string orderNumber);
    }
}
