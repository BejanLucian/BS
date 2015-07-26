using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TaskPlanner.Infrastructure.Context
{
    internal class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly IWorkflowContextIdProvider _contextIdProvider;
        private readonly Func<IUnitOfWork> _createUnitOfWork;
        private static readonly IDictionary<int,IUnitOfWork> Instances=new ConcurrentDictionary<int, IUnitOfWork>();
        public UnitOfWorkProvider(IWorkflowContextIdProvider contextIdProvider, Func<IUnitOfWork> createUnitOfWork)
        {
            _contextIdProvider = contextIdProvider;
            _createUnitOfWork = createUnitOfWork;
        }

        public IUnitOfWork GetCurrent()
        {
            IUnitOfWork currentUow;
            var currentContextId = _contextIdProvider.GetWorflowAttachedContextIdentifier();
            var newUow = _createUnitOfWork();
            newUow.OnDispose += OnUowDispose;

            lock (Instances)
            {
                if (!Instances.ContainsKey(currentContextId))
                {
                    Instances.Add(currentContextId, newUow);
                }

                currentUow = Instances[currentContextId];
            }
           
            
            return currentUow;
        }

        private void OnUowDispose(object sender, EventArgs args)
        {
            var uow = (IUnitOfWork)sender;
            uow.OnDispose -= OnUowDispose;

            lock (Instances)
            {
                foreach (var keyValuePair in Instances)
                {
                    if (keyValuePair.Value == uow)
                    {
                        Instances.Remove(keyValuePair);
                        break;
                    }
                }
            }
        }
    }
}
