using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
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

        public IEnumerable<MovieLiteDto> GetHotestMovies()
        {
            var hostestMovies = Repository.Query(x => true).OrderBy(x => x.LikedCount).ToList();
            return MapCollection<Movie, MovieLiteDto>(hostestMovies);
        }

        public IEnumerable<MovieLiteDto> GetLatestMovies()
        {
            var latestMovies = Repository.Query(x => true).OrderBy(x => x.RecordCreatedTime).ToList();
            return MapCollection<Movie, MovieLiteDto>(latestMovies);
        }
    }
}
