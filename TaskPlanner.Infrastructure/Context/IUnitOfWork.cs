using System;

namespace TaskPlanner.Infrastructure.Context
{
    public interface IUnitOfWork : IDisposable
    {
        event EventHandler OnDispose;
        void CommitChanges();
    }
}