using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlyboMovie.Data;
using FlyboMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages
{
    public class DetailModel : PageModel
    {
        AppDbContext _dbContext;

        public Movie Movie { get; set; }

        public bool IsMoviePayed { get; set; }

        public DetailModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
            var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier).Value;

            Movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            var buyOrder = _dbContext.BuyOrders.FirstOrDefault(bo=>bo.UserId == userId
                &&bo.MovieId == Movie.Id 
                && bo.Status != Common.BuyOrderStatus.Created);
            IsMoviePayed = buyOrder != null ? true : false;
        }

        public JsonResult OnGetPayed(int movieId)
        {
            IsMoviePayed = true;
            return new JsonResult(true);
        }
    }
}