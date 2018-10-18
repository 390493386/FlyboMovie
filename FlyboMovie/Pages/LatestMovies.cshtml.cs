using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Dtos;
using FlyboMovie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages
{
    public class LatestMoviesModel : PageModel
    {
        private IMovieService _movieService;
        public readonly string TabName = "LatestMovies";

        public IList<MovieLiteDto> LatestMovies { get; set; }

        public LatestMoviesModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void OnGet(string keywords)
        {
            LatestMovies = _movieService.GetLatestMovies();
        }
    }
}