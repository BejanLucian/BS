using TaskPlanner.Domain.StorageIoc;

namespace TaskPlanner.DataAccess.Repositories
{
    internal class RepositoryBase<T> : IRepository<T>
    {
        public RepositoryBase()
        {
            
        }

        public void Add(T task)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T task)
        {
            throw new System.NotImplementedException();
        }
    }
}
