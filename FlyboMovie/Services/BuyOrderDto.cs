using FlyboMovie.Common;

namespace FlyboMovie.Services
{
    public class BuyOrderDto
    {
        public string OrderNumber { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string ValidationCode { get; set; }
        public BuyOrderStatus Status { get; set; }
    }
}