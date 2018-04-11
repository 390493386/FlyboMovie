using FlyboMovie.Common;
using FlyboMovie.Data.Repository;
using FlyboMovie.Dtos;
using FlyboMovie.Models;

namespace FlyboMovie.Services.Implement
{
    public class UserService : DataServiceBase<User, UserDto, string>, IUserService
    {
        public UserService(IUnitOfWork unitOfwork, IUserRepository userRepository)
            : base(userRepository, unitOfwork)
        {
        }
    }
}
