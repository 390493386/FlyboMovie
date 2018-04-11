using AutoMapper;
using FlyboMovie.Common;
using FlyboMovie.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlyboMovie.Services
{
    public class ServiceBase
    {
        protected IUnitOfWork UnitOfWork { get; }

        public ServiceBase(IUnitOfWork unitOfwork)
        {
            UnitOfWork = unitOfwork;
        }

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        public IEnumerable<TTarget> MapCollection<TSource, TTarget>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TTarget>>(source);
        }

        public IList<TTarget> MapCollection<TSource, TTarget>(IList<TSource> source)
        {
            return Mapper.Map<IList<TSource>, IList<TTarget>>(source);
        }
    }

    public class DataServiceBase<TModel, TDto, TId> : ServiceBase, IDataService<TModel, TDto, TId>
        where TModel : RecordBase<TId>
        where TId : IEquatable<TId>
    {
        protected IRecordRepository<TModel, TId> Repository { get; set; }

        public DataServiceBase(IRecordRepository<TModel, TId> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Repository = repository;
        }

        public TDto GetById(TId id)
        {
            var model = Repository.GetByIdWithoutTracking(id);
            return Map<TModel, TDto>(model);
        }

        public IEnumerable<TDto> GetAll()
        {
            var modelList = Repository.Query(x => true).ToList();
            return MapCollection<TModel, TDto>(modelList);
        }

        public IEnumerable<TDto> GetAllActive()
        {
            var modelList = Repository.QueryWithTracking(x => !x.IsInactive).ToList();
            return MapCollection<TModel, TDto>(modelList);
        }

        public IEnumerable<TDto> Query(Expression<Func<TModel, bool>> where)
        {
            var modelList = Repository.Query(where).ToList();
            return MapCollection<TModel, TDto>(modelList);
        }

        public TDto Add(TDto dto)
        {
            var model = Map<TDto, TModel>(dto);
            model = Repository.Add(model);
            UnitOfWork.SaveChanges();

            return Map<TModel, TDto>(model);
        }

        public TDto Update(TDto dto)
        {
            var model = Map<TDto, TModel>(dto);
            model = Repository.Update(model);
            UnitOfWork.SaveChanges();

            return Map<TModel, TDto>(model);
        }

        public bool Destroy(TId id)
        {
            return Repository.Destroy(id);
        }

        public bool Delete(TId id)
        {
            return Repository.Delete(id);
        }
    }
}
