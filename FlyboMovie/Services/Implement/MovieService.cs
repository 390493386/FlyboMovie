using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using FlyboMovie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Services.Implement
{
    public class MovieService : DataServiceBase<Movie, MovieDto, int>, IMovieService
    {
        private IOrderNumberSettingService _orderNumberSettingService;

        public MovieService(IUnitOfWork unitOfWork, IMovieRepository movieRepository,
            IOrderNumberSettingService orderNumberSettingService)
            : base(movieRepository, unitOfWork)
        {
            _orderNumberSettingService = orderNumberSettingService;
        }

        public IList<MovieLiteDto> GetHotestMovies()
        {
            var hostestMovies = Repository.Query(x => true).OrderBy(x => x.LikedCount).ToList();
            return MapCollection<Movie, MovieLiteDto>(hostestMovies);
        }

        public IList<MovieLiteDto> GetLatestMovies()
        {
            var latestMovies = Repository.Query(x => true).OrderBy(x => x.RecordCreatedTime).ToList();
            return MapCollection<Movie, MovieLiteDto>(latestMovies);
        }

        public IList<MovieLiteDto> Search(string keywords)
        {
            var results = Repository.Query(x => x.Name.Contains(keywords)).ToList();
            return MapCollection<Movie, MovieLiteDto>(results);
        }

        public MovieDto CreateMovie(MovieDto movie)
        {
            movie.MovieNumber = _orderNumberSettingService.GenerateOrderNumber(OrderType.Movie);
            movie.TrySeconds = movie.TrySeconds ?? 10;
            movie.Price = 500;
            return Add(movie);
        }

        public Page<MovieLiteDto> SearchMovies(MovieSearchCriteria searchCriteria)
        {
            var moviesQuery = Repository.Query(x => true);
            if (!String.IsNullOrEmpty(searchCriteria.MovieName))
            {
                moviesQuery = moviesQuery.Where(x => x.Name != null && x.Name.Contains(searchCriteria.MovieName));
            }
            var totalCount = moviesQuery.Count();
            var movies = moviesQuery
                .Skip((searchCriteria.PageIndex - 1) * searchCriteria.PageSize)
                .Take(searchCriteria.PageSize).ToList();
            var moviesDto = MapCollection<Movie, MovieLiteDto>(movies);

            return new Page<MovieLiteDto>(searchCriteria.PageIndex, searchCriteria.PageSize, totalCount, moviesDto);
        }
    }
}
