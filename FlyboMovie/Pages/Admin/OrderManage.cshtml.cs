using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Dtos;
using FlyboMovie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages.Admin
{
    public class OrderManageModel : PageModel
    {
        private IBuyOrderService _buyOrderService;

        public List<BuyOrderLiteDto> BuyOrders { get; set; }

        public OrderManageModel(IBuyOrderService buyOrderService)
        {
            _buyOrderService = buyOrderService;
        }

        public void OnGet(string orderNum)
        {
            BuyOrders = _buyOrderService.SearchCreatedOrders(orderNum);
        }
    }
}