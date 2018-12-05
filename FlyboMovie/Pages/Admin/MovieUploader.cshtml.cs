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
    public class MovieUploaderModel : PageModel
    {
        private IMovieService _movieService;

        [BindProperty]
        public MovieUploadViewModel ViewModel { get; set; }

        public MovieUploaderModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (ViewModel.Poster.ImgData.Length > 1048576)
                {
                    ModelState.AddModelError("ViewModel.Poster", "文件大小超过限制（1M）！");
                    return;
                }
                if (ViewModel.Movie != null && ViewModel.Movie.Length > 209715200)
                {
                    ModelState.AddModelError("ViewModel.Movie", "文件大小超过限制（200M）！");
                    return;
                }

                var moviePath = FileHelper.SaveFile(FileHelper.VideoPath, ViewModel.Movie);
                //var posterPath = FileHelper.SaveFile(FileHelper.ImagePath, ViewModel.Poster);

                MovieDto movie = new MovieDto()
                {
                    Name = ViewModel.Title,
                    //PosterLink = FileHelper.RelativeImagePath + posterPath,
                    MovieLink1 = FileHelper.RelativeVideoPath + moviePath,
                    TrySeconds = ViewModel.TrySeconds
                };
                _movieService.CreateMovie(movie);
            }
        }
    }
}