using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Dtos
{
    public class BuyOrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string ValidationCode { get; set; }
        public BuyOrderStatus Status { get; set; }
        public DateTime? ConfirmTime { get; set; }
        public DateTime? ConsumeTime { get; set; }
    }

    public class BuyOrderLiteDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public BuyOrderStatus Status { get; set; }
        public DateTime RecordCreatedTime { get; set; }
    }
}
