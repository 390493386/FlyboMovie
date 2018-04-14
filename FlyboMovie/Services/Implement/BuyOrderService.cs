using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyboMovie.Services.Implement
{
    public class BuyOrderService: DataServiceBase<BuyOrder, BuyOrderDto, int>, IBuyOrderService
    {
        private IOrderNumberSettingService _orderNumberSettingService;
        private IMovieRepository _movieRepository;
        public BuyOrderService(IUnitOfWork unitOfWork, 
            IBuyOrderRepository buyOrderRepository,
            IOrderNumberSettingService orderNumberSettingService,
            IMovieRepository movieRepository)
            : base(buyOrderRepository, unitOfWork)
        {
            _orderNumberSettingService = orderNumberSettingService;
            _movieRepository = movieRepository;
        }

        public BuyOrderDto Create(BuyOrderDto buyOrder)
        {
            buyOrder.OrderNumber = _orderNumberSettingService.GenerateOrderNumber(OrderType.BuyOrder);
            buyOrder.Status = BuyOrderStatus.Created;
            return Add(buyOrder);
        }

        public List<BuyOrderLiteDto> SearchCreatedOrders(string orderNumber)
        {
            var ordersQuery = Repository.Query(x => x.Status == BuyOrderStatus.Created);
            if (!String.IsNullOrEmpty(orderNumber))
            {
                ordersQuery = ordersQuery.Where(x => x.OrderNumber != null && x.OrderNumber.Contains(orderNumber));
            }
            var orders = ordersQuery.Take(50).ToList();

            var movieIds = orders.Select(x => x.MovieId).ToList();
            var movies = _movieRepository.Query(x => movieIds.Contains(x.Id)).ToList();
            var ordersDto = MapCollection<BuyOrder, BuyOrderLiteDto>(orders);
            foreach (var order in ordersDto)
            {
                var movie = movies.FirstOrDefault(x => x.Id == order.MovieId);
                order.MovieName = movie != null ? movie.Name : null;
            }

            return ordersDto.ToList();
        }
    }
}
