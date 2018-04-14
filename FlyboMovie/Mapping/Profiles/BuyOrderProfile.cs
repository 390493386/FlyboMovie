using AutoMapper;
using FlyboMovie.Dtos;
using FlyboMovie.Models;

namespace FlyboMovie.Mapping.Profiles
{
    public class BuyOrderProfile: Profile
    {
        public BuyOrderProfile()
        {
            CreateMap<BuyOrder, BuyOrderDto>();
            CreateMap<BuyOrderDto, BuyOrder>();

            CreateMap<BuyOrder, BuyOrderLiteDto>();
            CreateMap<BuyOrderLiteDto, BuyOrder>();
        }
    }
}
