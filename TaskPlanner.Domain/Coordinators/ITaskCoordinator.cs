using System;

namespace TaskPlanner.Domain.Coordinators
{
    public interface ITaskCoordinator
    {
        void CreateNewTask(string title, string description, Guid parentId);
    }
}
