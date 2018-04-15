using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Data.Repository.Implement;
using FlyboMovie.Dtos;
using FlyboMovie.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyboMovie.Services.Implement
{
    public class UserService : DataServiceBase<User, UserDto, string>, IUserService
    {
        private IUserRoleRepository _userRoleRepository;
        private IRoleRepository _roleRepository;

        public UserService(IUnitOfWork unitOfwork,
            IUserRepository userRepository, 
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository)
            : base(userRepository, unitOfwork)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public UserLoginDto GetUserByAccount(string account)
        {
            var user = Repository.Query(x => x.Account == account).FirstOrDefault();
            return Map<User, UserLoginDto>(user);
        }

        public IList<RoleDto> GetUserRolesByUserId(string userId)
        {
            var userRoles = _userRoleRepository.Query(x => x.UserId == userId).ToList();
            if (userRoles.Count == 0)
            {
                return null;
            }
            var userRoleIds = userRoles.Select(x => x.RoleId).ToList();
            var roles = _roleRepository.Query(x => userRoleIds.Contains(x.Id)).ToList();
            return MapCollection<Role, RoleDto>(roles);
        }

        public ClaimsPrincipal BuildPrincipal(UserLoginDto user, IList<RoleDto> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            if (roles != null && roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    claims.Add(new Claim(ClaimTypes.Role, "ss"));
                }
            }
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var pricipal = new ClaimsPrincipal(identity);

            return pricipal;
        }
    }
}
