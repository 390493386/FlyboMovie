using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Common;
using FlyboMovie.Dtos;
using FlyboMovie.Services;
using FlyboMovie.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages.Admin
{
    [Authorize(Roles ="Admin")]
    public class OrderManageModel : PageModel
    {
        private IBuyOrderService _buyOrderService;

        [BindProperty]
        public int PageIndex { get; set; }

        [BindProperty]
        public int PageSize { get; set; }

        [BindProperty]
        public string OrderNumber { get; set; }

        public Page<BuyOrderLiteDto> BuyOrders { get; set; }

        public OrderManageModel(IBuyOrderService buyOrderService)
        {
            _buyOrderService = buyOrderService;
        }

        public void OnGet([FromQuery] OrderSearchCriteria searchCriteria)
        {
            PageIndex = searchCriteria.PageIndex;
            PageSize = searchCriteria.PageSize;
            OrderNumber = searchCriteria.OrderNumber;

            BuyOrders = _buyOrderService.SearchCreatedOrders(searchCriteria);
        }

        public JsonResult OnGetConfirmOrder(int orderId)
        {
            _buyOrderService.ConfirmOrder(orderId);
            return new JsonResult(true);
        }
    }
}