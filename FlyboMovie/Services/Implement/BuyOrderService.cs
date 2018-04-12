using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Models;

namespace FlyboMovie.Services.Implement
{
    public class BuyOrderService: DataServiceBase<BuyOrder, BuyOrderDto, int>, IBuyOrderService
    {
        private IOrderNumberSettingService _orderNumberSettingService;
        public BuyOrderService(IUnitOfWork unitOfWork, 
            IBuyOrderRepository buyOrderRepository,
            IOrderNumberSettingService orderNumberSettingService)
            : base(buyOrderRepository, unitOfWork)
        {
            _orderNumberSettingService = orderNumberSettingService;
        }

        public BuyOrderDto Create(BuyOrderDto buyOrder)
        {
            buyOrder.OrderNumber = _orderNumberSettingService.GenerateOrderNumber(OrderType.BuyOrder);
            buyOrder.Status = BuyOrderStatus.Created;
            return Add(buyOrder);
        }
    }
}
