using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Repository.Implement
{
    public class RoleRepository : RecordRepositoryBase<int, Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
