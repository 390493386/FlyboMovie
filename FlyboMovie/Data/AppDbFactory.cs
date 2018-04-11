using FlyboMovie.Common;
using System;

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
        ~AppDbFactory()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
