using FlyboMovie.Common;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using FlyboMovie.ViewModels;

namespace FlyboMovie.Services
{
    public interface IBuyOrderService: IDataService<BuyOrder, BuyOrderDto, int>
    {
        BuyOrderDto Create(BuyOrderDto buyOrder);
        Page<BuyOrderLiteDto> SearchCreatedOrders(OrderSearchCriteria searchCriteria);
        void ConfirmOrder(int orderId);
    }
}
