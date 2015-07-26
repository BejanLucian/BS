using System;
using System.Threading;
using TaskPlanner.Domain.Entities;
using TaskPlanner.Domain.StorageIoc;

namespace TaskPlanner.Domain.Coordinators
{
    public class TaskCoordinator
    {
        private readonly ITaskRepository _taskRepository;

        public TaskCoordinator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateNewTask(string title, string description, Guid parentId)
        {
            var parent = _taskRepository.GetById(parentId);
            var newTask = new Job(title, parent);
            newTask.Description = description;
      
            _taskRepository.Add(newTask);
        }
    }
}
