using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public int Points { get; set; }
    }

    public class UserLoginDto
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string Password { get; set; }
    }

    public class RoleDto
    {
        public string Name { get; set; }
    }

    public class UserRoleDto
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }
}
