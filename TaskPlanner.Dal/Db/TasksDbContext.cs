using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using TaskPlanner.DataAccess.Exceptions;
using TaskPlanner.Domain.Entities;

namespace TaskPlanner.DataAccess.Db
{
    internal class TasksDbContext : DbContext, ITasksDbContext
    {
        private const string ConnectionConfigurationName = "TaskPlannerDB";

        public TasksDbContext()
            : base(GetConnectionString())
        {
            // Database.SetInitializer(new DropCreateDatabaseTables<TasksDbContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TasksDbContext>());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public new IQueryable<TEntity> Set<TEntity>() where TEntity : class
        {
            return ((DbContext) this).Set<TEntity>();
        }

        public new IQueryable Set(Type entityType)
        {
            return DbContext.Set(entityType);
        }

        public void Add(object entityInstance)
        {
            DbContext.Set(entityInstance.GetType()).Add(entityInstance);
        }

        public void Remove(object entityInstance)
        {
            DbContext.Set(entityInstance.GetType()).Remove(entityInstance);
        }

        private static string GetConnectionString()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[ConnectionConfigurationName];
            if (connectionStringSettings != null)
            {
                return connectionStringSettings.ConnectionString;
            }

            throw new InvalidConfigurationException(string.Format("Db Connection settings for [{0}] not found in web.config", ConnectionConfigurationName));
        }

        private DbContext DbContext
        {
            get { return this; }
        }
    }
}
