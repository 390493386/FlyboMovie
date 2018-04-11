using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Data;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using FlyboMovie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages
{
    public class IndexModel : PageModel
    {
        private IMovieService MovieService;

        public IEnumerable<MovieLiteDto> Movies { get; set; }

        public IndexModel(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public void OnGet()
        {
            Movies = MovieService.GetLatestMovies();
        }
    }
}
