using FlyboMovie.Common;
using FlyboMovie.Dtos;
using FlyboMovie.Services;
using FlyboMovie.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class MovieManageModel : PageModel
    {
        private IMovieService _movieService;

        public MovieManageModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [BindProperty]
        public int PageIndex { get; set; }

        [BindProperty]
        public int PageSize { get; set; }

        [BindProperty]
        public string MovieName { get; set; }

        public Page<MovieLiteDto> Movies { get; set; }

        public void OnGet([FromQuery] MovieSearchCriteria searchCriteria)
        {
            PageIndex = searchCriteria.PageIndex;
            PageSize = searchCriteria.PageSize;
            MovieName = searchCriteria.MovieName;

            Movies = _movieService.SearchMovies(searchCriteria);
        }

        public JsonResult OnGetDeleteMovie(int movieId)
        {
            var result = _movieService.Destroy(movieId);
            return new JsonResult(result);
        }
    }
}