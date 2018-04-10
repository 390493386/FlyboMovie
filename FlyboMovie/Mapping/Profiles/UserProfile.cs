using AutoMapper;
using FlyboMovie.Mapping;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Mapping.Profiles
{
    public class UserProfile:Profile,IProfile
    {
        public UserProfile()
        {
            CreateMap<User, User>();
            CreateMap<Role, Role>();
            CreateMap<UserRole, UserRole>();
        }
    }
}
