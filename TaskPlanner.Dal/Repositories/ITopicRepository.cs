using System;
using System.Collections.Generic;
using TaskPlanner.Domain.Entities;

namespace TaskPlanner.DataAccess.Repositories
{
    public interface ITopicRepository
    {
        IEnumerable<Topic> GetByEnclosingTopicId(Guid? topicId);
        void Add(Topic instance);
        void Remove(Topic instance);
        Topic GetById(Guid id);
    }
}