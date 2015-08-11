using System;
using System.Collections.Generic;
using TaskPlanner.Domain.Entities;
using TaskPlanner.Domain.StorageIoc;

namespace TaskPlanner.Domain.Coordinators
{
    public class TaskCoordinator : ITaskCoordinator
    {
        private readonly ITaskRepository _taskRepository;

        public TaskCoordinator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateNewTask(string title, string description, Guid? enclosingTopicId)
        {
            var newTask = new Job(title);
            if ((enclosingTopicId.HasValue) && (enclosingTopicId != Guid.Empty))
            {
                var enclosingTopic = _taskRepository.GetById(enclosingTopicId.Value);
                newTask.EnclosingTopic = enclosingTopic as Topic;
            }
            newTask.Description = description;
      
            _taskRepository.Add(newTask);
        }

        public IEnumerable<ITask> GetTasks(Guid? enclosingTopicId)
        {
            return _taskRepository.GetByEnclosingTopicId(enclosingTopicId);
        }
    }
}
