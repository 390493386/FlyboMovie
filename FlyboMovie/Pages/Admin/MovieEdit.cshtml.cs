using FlyboMovie.Services;
using FlyboMovie.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class MovieEditModel : PageModel
    {
        private IMovieService _movieService;

        [BindProperty]
        public MovieEditViewModel Movie { get; set; }

        public MovieEditModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void OnGet(int id)
        {
            var movie = _movieService.GetById(id);
            Movie = new MovieEditViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                TrySeconds = movie.TrySeconds
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var movie = _movieService.GetById(Movie.Id);
                movie.Name = Movie.Name;
                movie.TrySeconds = Movie.TrySeconds;
                _movieService.Update(movie);
                return RedirectToPage("/Admin/MovieManage");
            }
            return Page();
        }
    }
}