using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskPlanner.Domain.Entities
{
    abstract public class TaskBase : ITask
    {
        public TaskBase(string title, ITask parent)
        {
            this.Title = title;
            this.Parent = parent;
        }

        public ITask Parent { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; set; }
        
        public  bool IsBlocked()
        {
            return Preconditions.Any(p => p.NeedsToBeDone());
        }

        public int GetNestingLevel()
        {
            return Preconditions.Max(x => x.GetNestingLevel()) + 1;
        }

        public bool IsJob()
        {
            return this.GetType() == typeof (Job);
        }
        public bool IsTopic()
        {
            return this.GetType() == typeof(Topic);
        }

        public Topic GetEnclosingTopic()
        {
            ITask currentTask = this;
            while (true)
            {
                if ((currentTask.Parent == null) || (currentTask.Parent.IsTopic()))
                {
                    return currentTask.Parent as Topic;
                }
                currentTask = currentTask.Parent;
            }
        }

        // Abstract:
        public abstract bool NeedsToBeDone();
        public abstract IList<ITask> Preconditions { get; }
        public abstract DateTime CompletedOn { get; }
        public abstract IEnumerable<Guid> AssignedTo { get; }
        public abstract TaskState State { get; }
    }
}
