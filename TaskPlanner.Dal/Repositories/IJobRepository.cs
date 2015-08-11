using System;
using System.Collections.Generic;
using TaskPlanner.Domain.Entities;
using TaskPlanner.Domain.StorageIoc;

namespace TaskPlanner.DataAccess.Repositories
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetByEnclosingTopicId(Guid? topicId);
        void Add(Job instance);
        void Remove(Job instance);
        Job GetById(Guid id);
    }
}