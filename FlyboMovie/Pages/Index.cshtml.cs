﻿using System;
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

        public string CurrntTab { get; set; }
        public string PageTitle { get; set; }
        public IList<MovieLiteDto> Movies { get; set; }

        public IndexModel(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public void OnGet(string tab, string keywords)
        {
            if (String.IsNullOrEmpty(keywords))
            {
                CurrntTab = String.IsNullOrEmpty(tab) ? "hottest" : tab;
                if (CurrntTab == "hottest")
                {
                    PageTitle = "人气";
                    Movies = MovieService.GetHotestMovies();
                }
                else if (CurrntTab == "latest")
                {
                    PageTitle = "最新";
                    Movies = MovieService.GetLatestMovies();
                }
            }
            else
            {
                CurrntTab = "search";
                PageTitle = "搜索结果";
                Movies = MovieService.Search(keywords);
            }
        }
    }
}
