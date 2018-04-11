using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FlyboMovie.Common
{
    public interface IDataService<TModel, TDto, TId>
        where TModel : RecordBase<TId>
        where TId : IEquatable<TId>
    {
        TDto GetById(TId id);
        IEnumerable<TDto> GetAll();
        IEnumerable<TDto> GetAllActive();
        IEnumerable<TDto> Query(Expression<Func<TModel, bool>> where);
        TDto Add(TDto dto);
        TDto Update(TDto dto);
        bool Destroy(TId id);
        bool Delete(TId id);
    }
}
