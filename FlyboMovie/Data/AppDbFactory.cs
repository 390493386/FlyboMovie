using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data
{
    public class AppDbFactory : IDbFactory
    {
        private AppDbContext _dbContext;

        public AppDbFactory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppDbContext Get()
        {
            return _dbContext;
        }

        private bool disposed;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
