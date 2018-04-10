using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Repository.Implement
{
    public class UserRepository : RecordRepositoryBase<string, User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
