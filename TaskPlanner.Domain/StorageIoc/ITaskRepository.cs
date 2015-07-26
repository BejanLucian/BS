using System;
using System.Collections;
using System.Collections.Generic;
using TaskPlanner.Domain.Entities;

namespace TaskPlanner.Domain.StorageIoc
{
    public interface ITaskRepository:IRepository<ITask>
    {
        IEnumerable<ITask> GetByParentId(Guid parentId);

        ITask GetById(Guid taskId);

    }
}
