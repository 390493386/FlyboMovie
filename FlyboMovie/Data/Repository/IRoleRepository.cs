using FlyboMovie.Data.Common;
using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Repository
{
    public interface IRoleRepository : IRecordRepository<Role, int>
    {
    }
}
