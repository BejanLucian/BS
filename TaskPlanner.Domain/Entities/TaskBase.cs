using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskPlanner.Domain.Entities
{
    abstract public class TaskBase : ITask
    {
        public TaskBase(string title)
        {
            this.Title = title;
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
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

        public Topic EnclosingTopic { get; set; }
     
        // Abstract:
        public abstract bool NeedsToBeDone();
        public abstract IList<ITask> Preconditions { get; }
        public abstract DateTime CompletedOn { get; }
        public abstract IEnumerable<Guid> AssignedTo { get; }
        public abstract TaskState State { get; }
    }
}
