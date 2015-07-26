using System;
using System.Collections.Generic;
using TaskPlanner.Domain.Exceptions;

namespace TaskPlanner.Domain.Entities
{
    public class Job : TaskBase
    {
        private readonly IList<ITask> _preconditions;
        private DateTime _completedOn;
        private IList<Guid> _assignedTo;
        private TaskState _state;

        public Job(string title, ITask parent):base(title, parent)
        {
            this._preconditions = new List<ITask>();
            this._assignedTo = new List<Guid>();
            this._state = TaskState.Created;
        }

        public override DateTime CompletedOn
        {
            get { return _completedOn; }
        }

        public override IEnumerable<Guid> AssignedTo
        {
            get { return _assignedTo; }
        }

        public override TaskState State
        {
            get { return _state; }
        }

        public override IList<ITask> Preconditions
        {
            get { return _preconditions; }
        }

        public override bool NeedsToBeDone()
        {
            return this.State == TaskState.Created ||
                   this.State == TaskState.InProgress;
        }

        public void SetState(TaskState newState)
        {
            if (newState != this.State)
            {
                switch (newState)
                {
                    case TaskState.Done:
                        if (this.IsBlocked())
                        {
                            throw new ValidationException(string.Format("The Job is blocked and cannot go to '{0}'.", newState));
                        }
                        break;
                }
                _state = newState;
            }
        }

        public void Complete()
        {
            _state = TaskState.Done;
            _completedOn = DateTime.UtcNow;
        }

        
        
        
    }
}
