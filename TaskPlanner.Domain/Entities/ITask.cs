using System;
using System.Collections.Generic;

namespace TaskPlanner.Domain.Entities
{
    public interface ITask : IEntity
    {
        string Title { get; }

        string Description { get; set; }

        DateTime CompletedOn { get; }

        IEnumerable<Guid> AssignedTo { get; }

        TaskState State { get; }

        bool IsBlocked();

        bool NeedsToBeDone();

        IList<ITask> Preconditions { get; }

        /// <summary>
        /// Gets the nesting level, relative to parent.
        /// </summary>
        /// <returns></returns>
        int GetNestingLevel();

        bool IsJob();
        bool IsTopic();

        Topic EnclosingTopic { get; set; }
    }

    public enum TaskState
    {
        Created = 0,
        InProgress = 1,
        Done = 2,
        Removed = 3
    }
}