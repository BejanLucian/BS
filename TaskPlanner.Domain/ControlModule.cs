using Microsoft.Practices.Unity;
using TaskPlanner.Domain.Coordinators;

namespace TaskPlanner.Domain
{
    public static class ControlModule
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ITaskCoordinator, TaskCoordinator>(new ContainerControlledLifetimeManager());
        }


    }
}
