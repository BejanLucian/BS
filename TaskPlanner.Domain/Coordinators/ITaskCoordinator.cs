using System;
using System.Collections;
using System.Collections.Generic;
using TaskPlanner.Domain.Entities;

namespace TaskPlanner.Domain.Coordinators
{
    public interface ITaskCoordinator
    {
        void CreateNewTask(string title, string description, Guid? parentId);
        IEnumerable<ITask> GetTasks(Guid? parentId);
    }
}
