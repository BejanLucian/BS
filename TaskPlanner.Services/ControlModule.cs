using Microsoft.Practices.Unity;
using TaskPlanner.Infrastructure.Context;

namespace TaskPlanner.Services
{
    public static class ControlModule
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IWorkflowContextIdProvider, ServiceCallContextIdProvider>(new ContainerControlledLifetimeManager());

        }
    }
}
