using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Repository.Implement
{
    public class UserRoleRepository : RecordRepositoryBase<int, UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
