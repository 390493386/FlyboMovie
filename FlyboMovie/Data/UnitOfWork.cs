using FlyboMovie.Common;

namespace FlyboMovie.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFacory)
        {
            _dbFactory = dbFacory;
        }

        public int SaveChanges()
        {
            return _dbFactory.Get().SaveChanges();
        }
    }
}
