using Microsoft.Practices.Unity;
using TaskPlanner.Infrastructure.Context;
using TaskPlanner.Services.DataControllers;

namespace TaskPlanner.Services
{
    public static class ControlModule
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IWorkflowContextIdProvider, ServiceCallContextIdProvider>(new ContainerControlledLifetimeManager());
          
        }
    }
}
