using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlanner.DataAccess.Db;
using TaskPlanner.Domain.Entities;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.DataAccess.Repositories
{
    public class JobRepository : RepositoryBase<Job, ITasksDbContext>, IJobRepository
    {
        public JobRepository(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        public IEnumerable<Job> GetByEnclosingTopicId(Guid? topicId)
        {
            if ((topicId == null) || (topicId == Guid.Empty))
            {
                return EntitySet.Where(x => x.EnclosingTopic == null);
            }
            return EntitySet.Where(x => x.EnclosingTopic.Id == topicId);
        }
    }
}
