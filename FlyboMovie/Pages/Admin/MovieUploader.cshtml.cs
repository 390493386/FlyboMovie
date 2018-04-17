using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Common;
using FlyboMovie.Services;
using FlyboMovie.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages.Admin
{
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

        public async void OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (ViewModel.Poster.Length > 1048576)
                {
                    ModelState.AddModelError("ViewModel.Poster", "文件大小超过限制（1M）！");
                    return;
                }
                if (ViewModel.Movie.Length > 52428800)
                {
                    ModelState.AddModelError("ViewModel.Movie", "文件大小超过限制（50M）！");
                    return;
                }

                var moviePath = FileHelper.SaveFile(FileHelper.VideoPath, ViewModel.Movie);
                var posterPath = FileHelper.SaveFile(FileHelper.ImagePath, ViewModel.Poster);


                _movieService.CreateMovie(ViewModel.Title,
                    FileHelper.RelativeImagePath + posterPath, FileHelper.RelativeVideoPath + moviePath);
            }
        }
    }
}