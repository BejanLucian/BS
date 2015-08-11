using System;
using System.Linq;
using TaskPlanner.Domain.Entities;
using TaskPlanner.Domain.StorageIoc;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity,TDataContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TDataContext : IDbContext
    {
        protected IUnitOfWorkProvider _unitOfWorkProvider;

        public RepositoryBase(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public void Add(TEntity instance)
        {
            DataContext.Add(instance);
        }

        public void Remove(TEntity instance)
        {
            DataContext.Remove(instance);
        }

        public TEntity GetById(Guid id)
        {
            return EntitySet.FirstOrDefault(x => x.Id == id);
        }

        protected IQueryable<TEntity> EntitySet
        {
            get
            {
                return DataContext.Set<TEntity>();
            }
        }

        protected IDbContext DataContext
        {
            get
            {
                return _unitOfWorkProvider.GetCurrent().GetDataContext<TDataContext>();
            }
        }

    }
}
