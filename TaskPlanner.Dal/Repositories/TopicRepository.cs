using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlanner.DataAccess.Db;
using TaskPlanner.Domain.Entities;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.DataAccess.Repositories
{
    public class TopicRepository : RepositoryBase<Topic, ITasksDbContext>, ITopicRepository
    {
        public TopicRepository(IUnitOfWorkProvider unitOfWorkProvider)
            : base(unitOfWorkProvider)
        {
        }

        public IEnumerable<Topic> GetByEnclosingTopicId(Guid? topicId)
        {
            if ((topicId == null) || (topicId == Guid.Empty))
            {
                return EntitySet.Where(x => x.EnclosingTopic == null);
            }
            return EntitySet.Where(x => x.EnclosingTopic.Id == topicId);
        }
    }
}
