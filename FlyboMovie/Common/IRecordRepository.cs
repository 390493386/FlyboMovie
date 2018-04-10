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
        bool Destroy(TId id);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllActive();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> QueryAllActive();
    }
}
