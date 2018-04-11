using AutoMapper;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Mapping.Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieLiteDto>();

            CreateMap<MovieDto, Movie>();
        }
    }
}
