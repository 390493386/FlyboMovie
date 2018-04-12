using AutoMapper;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Mapping.Profiles
{
    public class OrderNumberSettingProfile:Profile
    {
        public OrderNumberSettingProfile()
        {
            CreateMap<OrderNumberSetting, OrderNumberSettingDto>();
            CreateMap<OrderNumberSettingDto, OrderNumberSetting>();
        }
    }
}
