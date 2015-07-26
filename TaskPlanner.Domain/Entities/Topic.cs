using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskPlanner.Domain.Entities
{
    public class Topic : TaskBase
    {
        public Topic(string title, ITask parent) : base(title, parent)
        {
            Subtasks = new List<ITask>();
        }

        public IList<ITask> Subtasks { get; private set; }

        public override TaskState State
        {
            get
            {
                if (!this.Subtasks.Any() || this.Subtasks.All(x => x.State == TaskState.Created))
                {
                    return TaskState.Created;
                }
                if (this.Subtasks.All(x => x.State == TaskState.Done))
                {
                    return TaskState.Done;
                }
                if (this.Subtasks.All(x => x.State == TaskState.Removed))
                {
                    return TaskState.Removed;
                }

                return TaskState.InProgress;
            }
        }

        public override DateTime CompletedOn
        {
            get { return Subtasks.Max(x => x.CompletedOn); }
        }

        public override IEnumerable<Guid> AssignedTo
        {
            get { return this.Subtasks.SelectMany(x => x.AssignedTo).Distinct(); }
        }


        public override bool NeedsToBeDone()
        {
            return Subtasks.Any(x => x.NeedsToBeDone());
        }

        public override IList<ITask> Preconditions
        {
            get
            {
                var externalPreconditions = new List<ITask>();
                var innerOrOuterPreconditions = this.Subtasks.SelectMany(x => x.Preconditions).Distinct();
                foreach (var candidate in innerOrOuterPreconditions)
                {
                    if (candidate.GetEnclosingTopic() != this)
                    {
                        externalPreconditions.Add(candidate);
                    }
                }

                return externalPreconditions;
            }
        }
    }
}
