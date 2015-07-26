using System.Configuration;
using System.Data.Entity;

namespace TaskPlanner.DataAccess.Db
{
    internal class TasksDbContext : DbContext, ITasksDbContext
    {
        private const string ConnectionConfigurationName = "PidgeonLoftDB";

        public TasksDbContext()
            : base(ConfigurationManager.ConnectionStrings[ConnectionConfigurationName].ConnectionString)
        {
            // Database.SetInitializer(new DropCreateDatabaseTables<TasksDbContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TasksDbContext>());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
