using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlyboMovie.Common;
using FlyboMovie.Data;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using FlyboMovie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages
{
    public class DetailModel : PageModel
    {
        IMovieService _movieService;
        IBuyOrderService _buyOrderService;

        public MovieDto Movie { get; set; }

        public BuyOrderDto MovieBuyOrder { get; set; }

        public DetailModel(IMovieService movieService, IBuyOrderService buyOrderService)
        {
            _movieService = movieService;
            _buyOrderService = buyOrderService;
        }

        public void OnGet(int movieId)
        {
            var userId = HttpContext.GetUserId();

            Movie = _movieService.GetById(movieId);
            var buyOrder = _buyOrderService.Query(bo => bo.UserId == userId && bo.MovieId == movieId)
                .FirstOrDefault();
            MovieBuyOrder = buyOrder;
        }

        public JsonResult OnGetBuyOrder(int movieId)
        {
            var userId = HttpContext.GetUserId();
            var buyOrder = _buyOrderService.Query(bo => bo.UserId == userId && bo.MovieId == movieId)
                .FirstOrDefault();
            if (buyOrder == null)
            {
                buyOrder = new BuyOrderDto()
                {
                    UserId = userId,
                    MovieId = movieId,
                };
                buyOrder = _buyOrderService.Create(buyOrder);
            }
            return new JsonResult(buyOrder);
        }
    }
}