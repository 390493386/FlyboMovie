using FlyboMovie.Common;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using FlyboMovie.ViewModels;
using System.Collections.Generic;

namespace FlyboMovie.Services
{
    public interface IMovieService : IDataService<Movie, MovieDto, int>
    {
        IList<MovieLiteDto> GetLatestMovies();
        IList<MovieLiteDto> GetHotestMovies();
        IList<MovieLiteDto> Search(string keywords);
        MovieDto CreateMovie(MovieDto movie);
        Page<MovieLiteDto> SearchMovies(MovieSearchCriteria searchCriteria);
    }
}
