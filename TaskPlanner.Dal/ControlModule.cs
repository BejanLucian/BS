using Microsoft.Practices.Unity;
using TaskPlanner.DataAccess.Db;

namespace TaskPlanner.DataAccess
{
    public static class ControlModule
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<ITasksDbContext, TasksDbContext>();
        }
    }
}
