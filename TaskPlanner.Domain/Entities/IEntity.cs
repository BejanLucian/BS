using System;

namespace TaskPlanner.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
