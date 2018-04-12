using AutoMapper;
using FlyboMovie.Models;
using FlyboMovie.Services;

namespace FlyboMovie.Mapping.Profiles
{
    public class BuyOrderProfile: Profile
    {
        public BuyOrderProfile()
        {
            CreateMap<BuyOrder, BuyOrderDto>();
            CreateMap<BuyOrderDto, BuyOrder>();
        }
    }
}
