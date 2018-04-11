using FlyboMovie.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FlyboMovie.Data
{
    public abstract class RecordRepositoryBase<TId, TEntity>
        where TId : IEquatable<TId>
        where TEntity : RecordBase<TId>
    {
        private AppDbContext _dbContext;
        private DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public RecordRepositoryBase(IDbFactory dbFactory)
        {
            _dbContext = dbFactory.Get();
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            entity.RecordCreatedTime = DateTime.Now;
            entity.RecordCreatedUser = -1;
            DbSet.Add(entity);
            return entity;
        }

        public bool Delete(TId id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            entity.IsInactive = true;
            Update(entity);
            return true;
        }

        public bool Destroy(TId id)
        {
            var entity = GetById(id);
            return Destroy(entity);
        }

        public bool Destroy(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            DbSet.Remove(entity);
            return true;
        }

        public TEntity Update(TEntity entity)
        {
            entity.RecordUpdatedTime = DateTime.Now;
            entity.RecordUpdatedUser = -1;
            if (!IsUnderTracking(entity))
            {
                DbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            return entity;
        }
        public TEntity GetById(TId id)
        {
            return QueryWithTracking(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public TEntity GetByIdWithoutTracking(TId id)
        {
            return Query(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.AsNoTracking().Where(where);
        }

        public IQueryable<TEntity> QueryWithTracking(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where);
        }

        public bool IsUnderTracking(object entity)
        {
            return _dbContext.Entry(entity).State != EntityState.Detached;
        }
    }
}
