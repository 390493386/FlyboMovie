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
        public MovieService(IUnitOfWork unitOfWork, IMovieRepository movieRepository)
            : base(movieRepository, unitOfWork)
        {
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

        public MovieDto CreateMovie(string name, string posterPath, string moviePath,
            int price = 500, int trySeconds = 5)
        {
            var movie = new MovieDto()
            {
                Name = name,
                LikedCount = 0,
                CollectedCount = 0,
                PosterLink = posterPath,
                MovieLink1 = moviePath,
                Price = price,
                TrySeconds = trySeconds,
            };
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
