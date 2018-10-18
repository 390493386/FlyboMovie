using FlyboMovie.Dtos;
using FlyboMovie.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace FlyboMovie.Pages
{
    public class HottestMoviesModel : PageModel
    {
        private IMovieService _movieService;

        public readonly string TabName = "HottestMovies";
        public IList<MovieLiteDto> HottestMovies { get; set; }

        public HottestMoviesModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void OnGet(string keywords)
        {
            HottestMovies = _movieService.GetHotestMovies();
        }
    }
}