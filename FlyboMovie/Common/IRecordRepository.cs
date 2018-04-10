using FlyboMovie.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FlyboMovie.Data.Common
{
    public interface IRecordRepository<TEntity,TId>
        where TEntity : RecordBase<TId>
        where TId:IEquatable<TId>
    {
        TEntity Add(TEntity entity);
        bool Delete(TId id);
        bool Delete(TEntity entity);
        bool Destroy(TId id);
        bool Destroy(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity GetById(TId id);
        TEntity GetByIdWithoutTracking(TId id);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> QueryWithTracking(Expression<Func<TEntity, bool>> where);
    }
}
