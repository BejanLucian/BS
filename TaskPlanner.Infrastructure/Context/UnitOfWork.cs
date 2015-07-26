using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskPlanner.Infrastructure.Context
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IList<IDbContext> _dbContexts;
        private readonly IDataContextFactory _dataContextFactory;

        public event EventHandler OnDispose;

        public UnitOfWork(IDataContextFactory dataContextFactory)
        {
            _dbContexts = new List<IDbContext>();
            _dataContextFactory = dataContextFactory;
        }

        public T GetDataContext<T>() where T : IDbContext
        {
            var existingDataContext = _dbContexts.SingleOrDefault(x => x.GetType() == typeof (T));

            if (existingDataContext == null)
            {
                existingDataContext = _dataContextFactory.Create<T>();
                _dbContexts.Add(existingDataContext);
            }

            return (T)existingDataContext;
        }

        public void CommitChanges()
        {
            foreach (var dbContext in _dbContexts)
            {
                dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (OnDispose != null)
            {
                OnDispose(this, null);
            }

            foreach (var dbContext in _dbContexts)
            {
                dbContext.Dispose();
            }
        }
    }
}
