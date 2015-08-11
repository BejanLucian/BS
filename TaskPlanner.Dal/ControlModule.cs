using Microsoft.Practices.Unity;
using TaskPlanner.DataAccess.Db;
using TaskPlanner.DataAccess.Repositories;
using TaskPlanner.Domain.StorageIoc;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.DataAccess
{
    public static class ControlModule
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ITasksDbContext, TasksDbContext>();
            container.RegisterType<IDataContextFactory, DataContextFactory>();
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<IJobRepository, JobRepository>();
            container.RegisterType<ITopicRepository, TopicRepository>();

            
            
        }
    }
}
