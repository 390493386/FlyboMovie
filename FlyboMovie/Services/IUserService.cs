using FlyboMovie.Common;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyboMovie.Services
{
    public interface IUserService : IDataService<User, UserDto, string>
    {
        UserLoginDto GetUserByAccount(string account);
        IList<RoleDto> GetUserRolesByUserId(string userId);
        ClaimsPrincipal BuildPrincipal(UserLoginDto user, IList<RoleDto> roles);
    }
}
