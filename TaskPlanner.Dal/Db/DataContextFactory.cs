using TaskPlanner.DataAccess.Exceptions;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.DataAccess.Db
{
    internal class DataContextFactory : IDataContextFactory
    {
        public IDbContext Create<T>() where T : IDbContext
        {
            var dataContextType = typeof (T);
            if (dataContextType == typeof(ITasksDbContext))
            {
                return new TasksDbContext();
            }

            throw new InvalidDataContextException(dataContextType);
        }
    }
}
