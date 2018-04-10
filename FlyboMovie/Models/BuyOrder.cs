using FlyboMovie.Common;
using System;

namespace FlyboMovie.Models
{
    public class BuyOrder : RecordBase<int>
    {
        public string OrderNumber { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }

        public string ValidationCode { get; set; }

        public BuyOrderStatus Status { get; set; }

        public DateTime? ConfirmTime { get; set; }

        public DateTime? ConsumeTime { get; set; }
    }
}
