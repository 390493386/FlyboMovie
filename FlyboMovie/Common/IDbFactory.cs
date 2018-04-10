using FlyboMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Common
{
    public interface IDbFactory : IDisposable
    {
        AppDbContext Get();
    }
}
