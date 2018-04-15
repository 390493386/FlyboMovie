using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.ViewModels
{
    public class OrderSearchCriteria : PageSearch
    {
        public OrderSearchCriteria()
            : base(1, 20)
        {
        }

        public OrderSearchCriteria(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
        }

        public string OrderNumber { get; set; }
    }
}
